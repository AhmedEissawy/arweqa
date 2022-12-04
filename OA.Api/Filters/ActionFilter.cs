using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OA.Data.Domain;
using OA.Repo;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Api.Filters
{
    public class ActionFilter : IActionFilter
    {
        private readonly IUserAccessor _userAccessor;
        private readonly ProjectContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public ActionFilter(ProjectContext dbContext, IUserAccessor userAccessor, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
            _userAccessor = userAccessor;
            _userManager = userManager;
            _dbContext = dbContext;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            PathString path = context.HttpContext.Request.Path;

            string[] splitedUrl = path.ToString().Substring(1).Split('/');

            List<string> splittedUrlStrings = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                splittedUrlStrings.Add(splitedUrl[i]);
            }

            string baseRoute = string.Join('/', splittedUrlStrings);

            //TODO: Abdelrahman ==> Default Value Must Be (True) !!!!!! 
            bool isUnauthorized = false;

            bool hasAllowAnonymous = context.ActionDescriptor.EndpointMetadata.Any(em => em.GetType() == typeof(AllowAnonymousAttribute));

            if (!hasAllowAnonymous)
            {
                string userId = _userAccessor.GetCurrentUserId();

                //VWUserFeature userFeature = _dbContext.VWUserFeatures.FirstOrDefault(q => q.User_Id == Guid.Parse(userId) && q.Base_Route == baseRoute);

                //if (userFeature != null)
                //{
                //    isUnauthorized = false;
                //}

                if (isUnauthorized)
                {

                    context.Result = new UnauthorizedResult();
                }
            }
        }

    }
}

