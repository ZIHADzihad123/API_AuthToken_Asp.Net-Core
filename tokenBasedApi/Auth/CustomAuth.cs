

using BEL;
using BLL;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System.Net;

namespace tokenBasedApi.Auth
{
    public class CustomAuth : ActionFilterAttribute //ActionFilterAttribute die amra Authorization kori  ->  s2 
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)   //Action Execute howar age ei method call hoe.
        {

           var authHeader = filterContext.HttpContext.Session.GetString("Authorization");  //session theke Authorize Token pacchi
            //string authHeader = filterContext.HttpContext.Response.Headers["Authorization"];    //Header er Authorization er value authHeader e rakhe
            
            if (authHeader == null)
            {
               // filterContext.Result = new StatusCodeResult(HttpStatusCode.Forbidden, "Forbidden");
               // filterContext.Result = new StatusCodeResult((int)HttpStatusCode.NoContent);
                filterContext.Result = new ContentResult()
                {
                   
                StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = $"Null Token Received"
                };
                //filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;  //null value hole status 404 dekhabe 
                return;
            }
            else
            {
               
                string token = authHeader.ToString();
                var rs = AuthService.CheckValidityToken(token);
                
                if (!rs)
                {
                    filterContext.Result = new ContentResult()
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Content = $"Invalid Token Received"
                    };
                    // var a= filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                    //filterContext.Result = new StatusCodeResult((int)HttpStatusCode.NonAuthoritativeInformation);  //token asw but validate na hole ei message dekhbe
                    return;
                }
                else
                {
                    // filterContext.HttpContext.Request.Headers["Authorization"] = ''
                    //filterContext.HttpContext.Response.Headers["Authorization"] = token;
                    base.OnActionExecuting(filterContext);     //token thakle + validate hole controller e action e jabe
                }
            }

          
            
        }

        //public void OnAuthorization(AuthorizationFilterContext context)
        //{
        //    string authHeader = context.HttpContext.Request.Headers["Authorization"];
        //    if (authHeader == null)
        //    {
        //        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        //        // filterContext.HttpContext.Request.Body = "dasda";
        //    }
        //    else
        //    {
        //        string token = authHeader.ToString();
        //        var rs = AuthService.CheckValidityToken(token);
        //        if (!rs)
        //        {
        //            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        //        }
        //    }
          
        //}
    }


}
