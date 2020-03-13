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
    public class BasicCustomerAuthenticationAttribute: AuthorizationFilterAttribute
    {
        LoggedInAdministratorFacade adminFacade;
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization==null)
            {
                actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, "You must login with user name and password!");
                return;
            }
            string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
            string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
            string[] userNameAndPasswordArray = decodedAuthenticationToken.Split(':');
            string userName = userNameAndPasswordArray[0];
            string password = userNameAndPasswordArray[1];

            ILoginTokenBase loginToken = FlyingCenterSystem.GetInstance().Login("admin", "9999");
            adminFacade = new LoggedInAdministratorFacade();
            Customer customer = adminFacade.GetCustomerByUserName(userName);
            if (customer == null)
            {
                actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, "This user name is not exist!");
                return;
            }
            if(customer.PASSWORD == password)
            {
                ILoginTokenBase customerLoginToken = FlyingCenterSystem.GetInstance().Login(userName, password);
                actionContext.Request.Properties["login-customer"] = customerLoginToken;

            }
            actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "You are not allowed!");
        }

    }
}