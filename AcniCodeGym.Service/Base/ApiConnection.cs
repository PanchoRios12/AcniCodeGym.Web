using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcniCodeGym.Service.Base
{
    public class ApiConnection
    {
        //Url de la API sin el Swageer
        public static string ApiUrl = "https://localhost:44308/";

        public static class EndPoints
        {
            public static string Empleado = "api/Empleado/";
            public static string Usuario = "api/Usuario/";
   
        }
    }
}
