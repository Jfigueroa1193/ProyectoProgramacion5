﻿using ProyectoProgramacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoProgramacion.Controllers
{
    public class ProvinciaController : Controller
    {
        // GET: Provincia
        public ActionResult CargarDatos()
        {
            ProvinciaModelo modelProvincia = new ProvinciaModelo();
            var respuesta = modelProvincia.ConsultarTodos();
            if (respuesta == null)
            {
                return Json(respuesta, JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }
        }
    }
}