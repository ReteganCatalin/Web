using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppASP.CommunicateLayer;

namespace WebAppASP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("LoginView");
        }
        public ActionResult Login()
        {
            string user = Request.Params["user"];
            string password = Request.Params["password"];
            Database CL = new Database();
            int result = CL.login(user, password);
            Session["currentUser"] = result;
            return Json(new { success = result });
        }
    }
}