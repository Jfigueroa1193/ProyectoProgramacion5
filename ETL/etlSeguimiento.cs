using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramacion.ETL
{
    public class etlSeguimiento
    {
        public long ID_SeguimientoSolicitud { get; set; } = 0;
        public etlSolicitud Solicitud { get; set; } = new etlSolicitud();
        public DateTime Fecha_Laborada { get; set; }
        public String Fecha { get; set; } = "";
        public int HorasNormales { get; set; } = 0;
        public int HorasExtras { get; set; } = 0;
        public int HorasDoble { get; set; } = 0;
        public string TrabajoRealizado { get; set; } = "";
    }
}