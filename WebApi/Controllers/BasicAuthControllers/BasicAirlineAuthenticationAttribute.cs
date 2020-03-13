using MainProject;
using MainProject.Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiPart.Controllers.BasicAuthAtt
{
    public class BasicAirlineAuthenticationAttribute: AuthorizationFilterAttribute
    {
        LoggedInAdministratorFacade adminFacade;
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, "You must login with user name and password!");
                return;
            }
            string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
            string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
            string[] userNameAndPasswordArray = decodedAuthenticationToken.Split(':');
            string userName = userNameAndPasswordArray[0];
            string password = userNameAndPasswordArray[1];

            ILoginTokenBase loginToken = FlyingCenterSystem.GetInstance().Login("admin", "9999");
            adminFacade = new LoggedInAdministratorFacade();
            List<AirlineCompany> airlines = adminFacade.GetAllAirlineCompanies();
            foreach (AirlineCompany airline in airlines)
            {
                if (userName==airline.USER_NAME && password ==airline.PASSWORD)
                {
                    ILoginTokenBase AirlineUserLoginToken = FlyingCenterSystem.GetInstance().Login(userName, password);
                    actionContext.Request.Properties["login-airlineCompany"] = airline;
                    actionContext.Request.Properties["airlineCompany-login-token"] = AirlineUserLoginToken;
                }
                if (userName == airline.USER_NAME && password != airline.PASSWORD)
                {
                    actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, "Wrong password");
                    return;
                }
            }
            actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "You are not allowed!");
        }
    }
}