using BasicAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace BasicAuthentication.Controllers
{
    public class EmployeeController : ApiController
    {
        [BasicAuthFilter]
        public HttpResponseMessage GetEmployees()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            var empList = new EmployeeBL().GetEmployees();
            switch (username.ToLower())
            {
                case "manisha":
                    return Request.CreateResponse(HttpStatusCode.OK,
                        empList.Where(e => e.Gender.ToLower() == "female").ToList());
                case "sunil":
                    return Request.CreateResponse(HttpStatusCode.OK,
                        empList.Where(e => e.Gender.ToLower() == "male").ToList());
                default:
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        }
    }



