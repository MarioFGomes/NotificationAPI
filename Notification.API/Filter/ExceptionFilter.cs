using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Notification.Aplication.ExceptionBase;
using System.Net;


namespace Notification.API.Filter {
    public class ExceptionFilter: IExceptionFilter {

        public void OnException(ExceptionContext context) {
            if (context.Exception is NotificationExceptions) {
                catchNotificationExceptions(context);

            } else {
                UnknownError(context);
            }
        }

        private void catchNotificationExceptions(ExceptionContext context) {

            if (context.Exception is ValidationErrorException) {
                ValidationErrorException(context);
            } 

        }

        private static void ValidationErrorException(ExceptionContext context) {
            var validationError = context.Exception as ValidationErrorException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult(new ResponseErrorJson(validationError.MessagesErros));
        }

        private static void UnknownError(ExceptionContext context) {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson("Unknown error"));
        }

    }
}
