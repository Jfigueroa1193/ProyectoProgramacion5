﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion.ETL
{
    public class etlEmpleado
    {
        //Cedula
        public string Cedula { get; set; }
        //Nombre
        public string Nombre { get; set; }

        //Primer apellido
        public string Primer_Apellido { get; set; }
        //Segundo Apellido
        public string Segundo_Apellido { get; set; }
        //Telefono
        public string Telefono { get; set; }
        //Correo
        public string Correo { get; set; }
        //Direccion
        public etlTipoTrabajo Direccion { get; set; }

    }
}