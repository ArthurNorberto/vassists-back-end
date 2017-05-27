using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace VAssistsProject.App_Start.Filters
{
    public class GeneralFilterException : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
        }
    }
}