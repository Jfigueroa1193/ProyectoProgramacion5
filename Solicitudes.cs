//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoProgramacion
{
    using System;
    using System.Collections.Generic;
    
    public partial class Solicitudes
    {
        public int solicitudId { get; set; }
        public int clienteId { get; set; }
        public int encargadoId { get; set; }
        public int tipoTrabajoId { get; set; }
        public int departamentoId { get; set; }
        public int equipoId { get; set; }
        public int solicitudJefatura { get; set; }
        public System.DateTime fechaReporte { get; set; }
        public System.DateTime horaEntrada { get; set; }
        public System.DateTime horaSalida { get; set; }
        public string tipoHora { get; set; }
        public long cantidadHoras { get; set; }
        public string solicitudMotivo { get; set; }
        public string motivoDetalle { get; set; }
        public string solicitudRepuestos { get; set; }
        public long equipoDetenido { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Departamentos Departamentos { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual Equipos Equipos { get; set; }
        public virtual TipoTrabajo TipoTrabajo { get; set; }
    }
}
