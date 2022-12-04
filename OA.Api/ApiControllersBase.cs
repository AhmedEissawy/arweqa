using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OA.Api.Filters;
using OA.Repo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace OA.Api
{
    [ApiController]
    [ServiceFilter(typeof(ActionFilter))]
    public class ApiControllersBase : ControllerBase
    {
        protected bool AuthorizeTeacherSubjects(Guid subjectId)
        {
            if (User.IsInRole(UserType.Teacher.ToString()))
            {
               
                var subjects = GetTeacherSubjects();

                if (subjects is null)
                    return false;

                if (!subjects.Any(a => a == subjectId))
                    return false;

            }
            return true;
        }

        protected IEnumerable<Guid> GetTeacherSubjects() 
        {
            if (User.IsInRole(UserType.Teacher.ToString()))
            {
                var subjectsClaim = User.FindFirst(a => a.Type == CustomClaimType.Subjects);

                if (subjectsClaim is null)
                    return null;
             
                
                return JsonSerializer.Deserialize<Guid[]>(subjectsClaim.Value);

              

            }
            return null;
        }
    }
}
