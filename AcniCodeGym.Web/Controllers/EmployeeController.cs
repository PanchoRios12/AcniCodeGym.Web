using AcniCodeGym.Service.Service;
using AcniCodeGym.Service.ViewModel;
using AcniCodeGym.Service.ViewModel.Base;
using AcniCodeGym.Web.Util;
using AcniCodeGym.Web.Util.Authenticate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace AcniCodeGym.Web.Controllers
{
    [Authorize]
  
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmpleadoService _empleadoService = new EmpleadoService();
        public ActionResult Index()
        {
            ViewBag.EmployeeName = SessionHelper.GetName();
            ViewBag.UserName = SessionHelper.GetUserName();
            ViewBag.Email = SessionHelper.GetEmail();
            return View();
        }
        public ActionResult Employee()
        {
            ViewBag.EmployeeName = SessionHelper.GetName();
            ViewBag.UserName = SessionHelper.GetUserName();
            ViewBag.Email = SessionHelper.GetEmail();
            return View();
        }
        public ActionResult CerrarSesion()
        {
            try
            {
                SessionHelper.DestroyUserSession();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public JsonResult crearEmpleado(EmpleadoDto empleadoDto)
        {
            var request = _empleadoService.crearEmpleado(empleadoDto, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet); ;
        }
        [HttpPost]
        public JsonResult listaEmpleadoPaginado(PaginationDto pagination, SortDto sort, QueryDto query)
        {
            pagination.sort = sort != null ? sort.sort : null;
            pagination.field = sort != null ? sort.field : null;
            pagination.Estado = query != null ? query.Estado : null;
            pagination.generalSearch = query != null ? query.generalSearch : null;
            var request = _empleadoService.listaEmpleadoPaginado(pagination, SessionHelper.GetToken());
            if (request == null || request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult editarEmpleado(EmpleadoDto empleadoDto)
        {
            var request = _empleadoService.actualizarEmpleado(empleadoDto, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult elminarEmpleado(int Id)
        {
            var request = _empleadoService.eliminarEmpleado(Id, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult obtenerEmpleadoPorId(int Id)
        {
            var request = _empleadoService.ObtenerEmpleadoPorId(Id, SessionHelper.GetToken());
            if (request.Result == null)
            {
                return new BadRequest();
            }
            return Json(request.Result, JsonRequestBehavior.AllowGet);
        }
    }
}
