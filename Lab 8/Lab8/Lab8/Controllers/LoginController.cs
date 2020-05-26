using Lab8.Communication_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Lab8.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View("ViewLogin");
        }

        public ActionResult Login()
        {
            string user = Request.Params["user"];
            string password = Request.Params["password"];
            CommunicationLayer CL = new CommunicationLayer();
            bool result = CL.login(user, password);
            return Json(new { success = result });
        }

    }
}