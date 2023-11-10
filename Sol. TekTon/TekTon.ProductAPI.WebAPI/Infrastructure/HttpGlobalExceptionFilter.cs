﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TekTon.ProductAPI.DTO;
using TekTon.ProductAPI.Seed;

namespace TekTon.ProductAPI.WebAPI.Infrastructure
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Request.Body.Position = 0;
            var bodyAsText = new StreamReader(context.HttpContext.Request.Body).ReadToEndAsync().Result;
            string controllerName = ((ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            string actionName = ((ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            string exception = context.Exception == null ? string.Empty : context.Exception.ToString();
            string exceptionMessage = context.Exception.InnerException == null ? string.Empty : context.Exception.InnerException.Message.ToString();

            //Log.Error("ControllerName: " + controllerName + " " +
            //          "ActionName: " + actionName + " " +
            //          "Exception: " + exception + " " +
            //          "Exception Message: " + exceptionMessage + " " +
            //          "Request Body: " + bodyAsText);

            if (context.Exception.GetType() == typeof(ApplicationValidationErrorsException))
            {
                var json = new ResponseDTO<string>
                {
                    Success = false,
                    Message = context.Exception.Message,
                    Errors = context.Exception.Message.Split("|").ToList()
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception.GetType() == typeof(ResourceNotFoundException))
            {
                var json = new ResponseDTO<string>
                {
                    Success = false,
                    Message = "No se encontró el recurso.",
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                var json = new ResponseDTO<string>
                {
                    Success = false,
                    Message = context.Exception.Message
                };

                context.Result = new InternalServerErrorObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.ExceptionHandled = true;
        }

        public class InternalServerErrorObjectResult : ObjectResult
        {
            public InternalServerErrorObjectResult(object error)
                : base(error)
            {
                StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
    }
}
