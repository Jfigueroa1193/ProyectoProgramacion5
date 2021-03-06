﻿using ProyectoProgramacion.ETL;
using ProyectoProgramacion.Filters;
using ProyectoProgramacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoProgramacion.Controllers
{
    public class EquipoController : Controller
    {
        // GET: Unidad
        [AutorizarUsuario(rol: "admin")]
        public ActionResult Index()
        {
            return View();
        }
        [AutorizarUsuario(rol: "admin")]
        public ActionResult CargarDatos()
        {
            EquipoModelo modelUnidad = new EquipoModelo();
            var respuesta = modelUnidad.ConsultarTodos();
            if (respuesta == null)
            {
                return Json(respuesta, JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }
        }
        //Agregar datos
        [AutorizarUsuario(rol: "admin")]
        [HttpPost]
        public ActionResult Agregar(etlEquipo uni)
        {
            try
            {
                EquipoModelo modelUnidad = new EquipoModelo();
                modelUnidad.GuardarConsulta(uni);
                return Json(uni, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e, JsonRequestBehavior.DenyGet);
            }


        }

        [HttpPost]
        [AutorizarUsuario(rol: "admin")]
        public ActionResult Eliminar(long id)
        {
            try
            {
                EquipoModelo modelUnidad = new EquipoModelo();
                modelUnidad.Eliminar(id);
                return Json(id, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e, JsonRequestBehavior.DenyGet);
            }


        }
        [AutorizarUsuario(rol: "admin")]
        public ActionResult Consultar(long id)
        {
            try
            {
                EquipoModelo modelUnidad = new EquipoModelo();
                var respuesta = modelUnidad.Consultar(id);
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e, JsonRequestBehavior.DenyGet);
            }


        }
        [AutorizarUsuario(rol: "admin")]
        [HttpPost]
        public ActionResult Actualizar(etlEquipo uni)
        {
            try
            {
                EquipoModelo modelUnidad = new EquipoModelo();
                modelUnidad.Actualizar(uni);
                return Json(uni, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e, JsonRequestBehavior.DenyGet);
            }


        }
    }
}