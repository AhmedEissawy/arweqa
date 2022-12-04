using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OA.Data.Domain;
using OA.Repo;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace OA.Api.MiddleWare
{
    public class ErrorHandlingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleWare> _logger;
 

        public ErrorHandlingMiddleWare(RequestDelegate next, ILogger<ErrorHandlingMiddleWare> logger)
        {
            this._next = next;
            this._logger = logger;
          
        }

        private readonly ITeacherRepo _teacherRepo;
        public async Task Invoke(HttpContext context,ProjectContext dbcontext , ITeacherRepo teacherRepo)
        {
           
            
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger , teacherRepo);
            }

        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlingMiddleWare> logger , ITeacherRepo teacherRepo)
        {
            object errors = null;
            context.Response.ContentType = "application/json";
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = JsonSerializer.Serialize($"{ex.Message} { ex.Source} {ex.StackTrace}  ", options);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var endPoint = context.GetEndpoint();

            switch (ex)
            {
                case RestException re:
                    await LogError(ex, teacherRepo, endPoint);
                    logger.LogError(ex, "REST ERROR");
                    errors = re.Errors;
                    context.Response.StatusCode = (int)re.Code;
                    break;
                case Exception e:

                    await LogError(ex, teacherRepo, endPoint);
                    logger.LogError(ex, "SERVER ERROR");


                    //Will be changed upon Production
                    //errors = string.IsNullOrWhiteSpace(e.Message) ? "Something Wrong Happened.Please Contact the support!" : e.Message;
                    break;
            }

            context.Response.ContentType = "application/json";
            if (errors != null)
            {
                var result = JsonSerializer.Serialize(new { errors });
                await context.Response.WriteAsync(result);
            }
        }

        private static async Task LogError(Exception ex, ITeacherRepo teacherRepo, Endpoint endPoint)
        {
            if (endPoint != null)
            {
                var controllerActionDescriptor = endPoint.Metadata.GetMetadata<ControllerActionDescriptor>();
                if (controllerActionDescriptor != null)
                {
                    await teacherRepo.ExceptionLogger(controllerActionDescriptor.ControllerName, controllerActionDescriptor.ActionName, ex);

                }

            }
        }
    }
}