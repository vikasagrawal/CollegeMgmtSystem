using College.UserProfile.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College.UserProfile.Ux.CustomAttributes
{
    public class HandleUIExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public virtual void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (filterContext.Exception != null)
            {
                if (filterContext.Exception is ValidationException)
                {
                    filterContext.ExceptionHandled = true;
                    filterContext.HttpContext.Response.Clear();
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                    filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.NotAcceptable;
                    filterContext.Result = ((ValidationException)filterContext.Exception).exceptionDetails;
                }
                else if (filterContext.Exception is GeneralException)
                {
                    filterContext.ExceptionHandled = true;
                    filterContext.HttpContext.Response.Clear();
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                    filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    filterContext.Result = ((GeneralException)filterContext.Exception).exceptionDetails;
                }
                else
                {
                    filterContext.ExceptionHandled = true;
                    filterContext.HttpContext.Response.Clear();
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                    filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                    filterContext.Result = new JsonResult { Data = new { Message = filterContext.Exception.Message } };
                }


            }
        }
    }
}