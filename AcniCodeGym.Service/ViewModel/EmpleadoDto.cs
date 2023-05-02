using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcniCodeGym.Service.ViewModel
{
    public class EmpleadoDto
    {
        /// <summary>
        /// Codigo Empleado
        /// </summary>
        /// <summary>
        public int id { get; set; }
        /// Codigo Empleado
        /// </summary>
        public string CodigoEmpleado { get; set; }
        /// <summary>
        /// Fecha Ingreso
        /// </summary>
        public DateTime FechaIngreso { get; set; }
        public string FechaIngresoString { get; set; }
        /// <summary>
        /// Nombres
        /// </summary>
        public string Nombres { get; set; }
        /// <summary>
        /// Apellidos
        /// </summary>
        public string Apellidos { get; set; }
        /// <summary>
        /// Celular
        /// </summary>
        public int Celular { get; set; }
        /// <summary>
        /// Cedula
        /// </summary>
        public string Cedula { get; set; }
        /// <summary>
        /// Direccion
        /// </summary>
        public string Direccion { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public bool Estado { get; set; }
    }
}
