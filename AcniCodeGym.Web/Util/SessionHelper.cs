using AcniCodeGym.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Security;

namespace AcniCodeGym.Web.Util
{
    public static class SessionHelper
    {
        public static bool ExistUserInSession()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
        public static void DestroyUserSession()
        {
            HttpContext.Current.Response.Cookies.Remove("name");
            HttpContext.Current.Response.Cookies.Remove("email");
            HttpContext.Current.Response.Cookies.Remove("user");
            HttpContext.Current.Response.Cookies.Remove("tyof");
            HttpContext.Current.Response.Cookies.Remove("img");
            FormsAuthentication.SignOut();
        }
        public static string GetToken()
        {
            string token = "";
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                if (ticket != null)
                {
                    token = ticket.UserData;
                }
            }
            return token;
        }

        public static string GetName()
        {
            string name = "";
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                name = Seguridad.DesEncriptar(HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.Cookies["name"].Value));
            }
            return name;
        }

        public static string GetEmail()
        {
            string name = "";
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                name = Seguridad.DesEncriptar(HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.Cookies["email"].Value));
            }
            return name;
        }

        public static string GetUserName()
        {
            string name = "";
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                name = Seguridad.DesEncriptar(HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.Cookies["user"].Value));
            }
            return name;
        }

        public static string GetImg()
        {
            string name = "";
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                name = Seguridad.DesEncriptar(HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.Cookies["img"].Value));
            }
            return name;
        }

        public static string GetTypeUser()
        {
            string name = "";
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                name = Seguridad.DesEncriptar(HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.Cookies["tyof"].Value));
            }
            return name;
        }

        public static void AddUserToSession(UsuarioDto user, string tipoUsuario)
        {
            bool persist = true;
            var cookie = FormsAuthentication.GetAuthCookie("usuario", persist);

            cookie.Name = FormsAuthentication.FormsCookieName;
            cookie.Expires = DateTime.Now.AddMonths(1);

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, user.Token);

            cookie.Value = FormsAuthentication.Encrypt(newTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);

            //Nombre
            HttpContext.Current.Response.Cookies.Remove("name");
            HttpContext.Current.Response.Cookies["name"].Value = Seguridad.Encriptar(user.NombreCompleto);
            HttpContext.Current.Response.Cookies["name"].Expires = DateTime.Now.AddDays(1);

            //correo
            HttpContext.Current.Response.Cookies.Remove("email");
            HttpContext.Current.Response.Cookies["email"].Value = Seguridad.Encriptar(user.Email);
            HttpContext.Current.Response.Cookies["email"].Expires = DateTime.Now.AddDays(1);

            //User name
            HttpContext.Current.Response.Cookies.Remove("user");
            HttpContext.Current.Response.Cookies["user"].Value = Seguridad.Encriptar(user.UserName);
            HttpContext.Current.Response.Cookies["user"].Expires = DateTime.Now.AddDays(1);

            //Nombre
            HttpContext.Current.Response.Cookies.Remove("tyof");
            HttpContext.Current.Response.Cookies["tyof"].Value = Seguridad.Encriptar(tipoUsuario);
            HttpContext.Current.Response.Cookies["tyof"].Expires = DateTime.Now.AddDays(1);

            //Imagen
            HttpContext.Current.Response.Cookies.Remove("img");
            HttpContext.Current.Response.Cookies["img"].Value = user.Imagen;
            HttpContext.Current.Response.Cookies["img"].Expires = DateTime.Now.AddDays(1);
        }
    }
}