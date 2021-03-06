﻿using Microsoft.Ajax.Utilities;
using ProyectoProgramacion.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoProgramacion.Models
{
    public class EmpleadoModelo
    {

        public List<etlEmpleado> ConsultarTodos()
        {
            using (var contextoBD = new ARMEntities())
            {
                var respuesta = contextoBD.Empleados.Select(x=>
                new etlEmpleado
                {
                    Cedula = x.empleadoCedula.Trim(),
                    Nombre = x.empleadoNombre.Trim(),
                    Primer_Apellido = x.empleadoPrimerA.Trim(),
                    Segundo_Apellido = x.empleadoSegundoA.Trim(),
                    Correo=x.empleadoCorreo.Trim(),

                }).ToList();
                return respuesta;
            }
            
        }
        public void GuardarConsulta(etlEmpleado  emp)
        {
            try
            {
                using (var contextoBD = new ARMEntities())
                {
                    Empleados item = new Empleados();
                    item.empleadoCedula = emp.Cedula.Trim();
                    item.empleadoNombre = emp.Nombre.Trim();
                    item.empleadoPrimerA= emp.Primer_Apellido.Trim();
                    item.empleadoSegundoA = emp.Segundo_Apellido.Trim();
                    item.empleadoCorreo = emp.Correo.Trim();


                    contextoBD.Empleados.Add(item);
                    contextoBD.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new System.Exception("Cedula ya existe");
            }
            
        }
        public void Eliminar(string id)
        {
            try
            {
                using (var contextoBD = new ARMEntities())
                {
                    Empleados emp = contextoBD.Empleados.Find(id.Trim());
                    contextoBD.Empleados.Remove(emp);
                    contextoBD.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new System.Exception("Error al eliminar");
            }

        }

        public etlEmpleado Consultar(string cedula)
        {
            try
            {
                using (var contextoBD = new ARMEntities())
                {
                    Empleados emp = contextoBD.Empleados.Find(cedula.Trim());
                    etlEmpleado empleado = new etlEmpleado
                    {
                        Cedula = emp.empleadoCedula.Trim(),
                        Nombre = emp.empleadoNombre.Trim(),
                        Primer_Apellido = emp.empleadoPrimerA.Trim(),
                        Segundo_Apellido = emp.empleadoSegundoA.Trim(),
                        Correo = emp.empleadoCorreo.Trim()

                    };
                    return empleado;
                }
            }
            catch (Exception e)
            {
                throw new System.Exception("Error al eliminar");
            }

        }
        public void Actualizar(etlEmpleado emp)
        {
            try
            {
                using (var contextoBD = new ARMEntities())
                {
                    Empleados item = contextoBD.Empleados.Find(emp.Cedula.Trim());
                    
                    item.empleadoNombre = emp.Nombre;
                    item.empleadoPrimerA = emp.Primer_Apellido;
                    item.empleadoSegundoA = emp.Segundo_Apellido;
                    item.empleadoCorreo = emp.Correo;
                    contextoBD.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new System.Exception("Error al actualizar");
            }

        }
    }
    
}