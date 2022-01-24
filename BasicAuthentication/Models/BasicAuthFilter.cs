using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BasicAuthentication.Models
{
    //step 4:
    //BasicAuthFilter class inheritance from the AuthorizationFilterAttribute
    //class and override the OnAuthorize() method which make this class Authorized filter and can be applied like other attribute to the action or controller level
    public class BasicAuthFilter:AuthorizationFilterAttribute
    {
        private const string Realm = " My Realm";
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //If the Authorization header is empty or null
            //then return Unauthorized
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

                // If the request was unauthorized, add the WWW-Authenticate header 
                // to the response which indicates that it require basic authentication
                //if (actionContext.Response.StatusCode == HttpStatusCode.Unauthorized)
                //{
                //    actionContext.Response.Headers.Add("WWW-Authenticate",
                //        string.Format("Basic realm=\"{0)\"",Realm));
                //}
            }
            else
            {
                //Get the authentication token from the request header
                string autheToken =actionContext.Request.Headers.Authorization.Parameter;
                //Decode the string
                string decode = Encoding.UTF8.GetString(Convert.FromBase64String(autheToken));
                //Convert the string into an string array
                string[] userpass = decode.Split(':');
                //First element of the array is the username
                string username = userpass[0];
                //Second element of the array is the password
                string password = userpass[1];
                //call the login method to check the username and password
                if (UserValidate.LogIn(username, password))
                {
                    //creating principal
                    var identity = new GenericIdentity(username);
                    IPrincipal principal = new GenericPrincipal(identity, null);
                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            
        }
    }
}