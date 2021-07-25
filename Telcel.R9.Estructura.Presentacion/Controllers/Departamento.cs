using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Telcel.R9.Estructura.Presentacion.Controllersd
{
    public class Departamento : Controller
    {

        public ActionResult GetAll()
        {
            Telcel.R9.Estructura.Result result = Telcel.R9.Estructura.Departamento.GetAllEF();

            Telcel.R9.Estructura.Departamento departamento = new Telcel.R9.Estructura.Departamento();

            departamento.Departamentos = result.Objects.ToList();

            return View(departamento);
        }
        // GET: Departamento
        public ActionResult Index()
        {
            return View();
        }
    }
}