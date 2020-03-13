using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net;
using System.Text;
using MainProject;
namespace WebApiPart.Controllers
{

    public class BasicAdminAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization==null )
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, "You must login with user name and password!");
                return;
            }
            string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
            string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
            string[] userNameAndPasswordArray = decodedAuthenticationToken.Split(':');
            string userName = userNameAndPasswordArray[0];
            string password = userNameAndPasswordArray[1];

            if (userName =="admin" && password == "9999")
            {
                ILoginTokenBase login = FlyingCenterSystem.GetInstance().Login(userName, password);
                actionContext.Request.Properties["login-token"] = login;
            }
                
            actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "You are not allowed!");

        }
    }
}
