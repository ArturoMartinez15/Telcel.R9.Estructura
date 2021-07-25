using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Telcel.R9.Estructura.Presentacion.Controllers
{
    public class Puesto : Controller
    {
        // GET: Catalagos

        public ActionResult GetAll()
        {
            Telcel.R9.Estructura.Result  result = Telcel.R9.Estructura.Puesto.GetAllEF();

            Telcel.R9.Estructura.Puesto puesto = new Telcel.R9.Estructura.Puesto();
            
            puesto.Puestos = result.Objects.ToList();

            return View(puesto);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}