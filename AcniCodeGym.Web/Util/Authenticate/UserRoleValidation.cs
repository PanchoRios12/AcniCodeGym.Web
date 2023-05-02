using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AcniCodeGym.Web.Util.Authenticate
{
    public class UserRoleValidation : ActionFilterAttribute
    {
        private string _role = "";
        public UserRoleValidation(string Role)
        {
            _role = Role;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string typeUser = SessionHelper.GetTypeUser();
            if (typeUser == "")
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index"
                }));
                return;
            }
            else if (_role == "Empleado")
            {
                if (_role != typeUser)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Employee",
                        action = "Index"
                    }));
                    return;
                }
            }
            else if (_role == "Cliente")
            {
                if (_role != typeUser)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Employee",
                        action = "Index"
                    }));
                    return;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}