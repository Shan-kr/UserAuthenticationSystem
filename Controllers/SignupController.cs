using Mark2.Models;
using Mark2.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mark2.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult Index()
        {
            return View("Signup");
        }

        public ActionResult SignUp(UserModel userModel)
        {
            //return "Result-> Username is:- "+userModel.Username +" Password is "+userModel.Password;

            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Signup(userModel);
            if (success)
            {
                return View("SignupSuccess", userModel);
            }
            else
            {
                return View("Signupfailure");
            }
        }
    }
}