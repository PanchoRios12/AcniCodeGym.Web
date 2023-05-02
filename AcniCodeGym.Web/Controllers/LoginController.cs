using AcniCodeGym.Service.Service;
using AcniCodeGym.Service.ViewModel;
using AcniCodeGym.Web.Util;
using AcniCodeGym.Web.Util.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcniCodeGym.Web.Controllers
{
    [NoLoginAttribute]
  
    public class LoginController : Controller
    {
        private readonly LoginService _loginService = new LoginService();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult Login(LoginDto user)
        {
            var request = _loginService.Login(user);
            if (request.Result == null)
            { 
                return new BadRequest();
            }
            SessionHelper.AddUserToSession(request.Result, "Empleado");
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
    }
}
