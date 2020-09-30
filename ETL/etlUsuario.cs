using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion.ETL
{
    public class etlUsuario
    {
        public long ID_Usuario { get; set; } = 0;
        public string Password { get; set; } = "";
        public etlEmpleado Empleado { get; set; } = new etlEmpleado();
        public etlRol Rol { get; set; } = new etlRol();
    }
}