using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Telcel.R9.Estructura.Presentacion.Controllers
{
    public class Empleado : Controller
    {
        // GET: Empleado

        public ActionResult GetAll()
        {
            Telcel.R9.Estructura.Result result = Telcel.R9.Estructura.Departamento.GetAllEF();

            Telcel.R9.Estructura.Empleado empleado = new Telcel.R9.Estructura.Empleado();

            empleado.Empleados = result.Objects.ToList();

            return View(empleado);
        }

        [HttpPost]
        public ActionResult GetAll(Telcel.R9.Estructura.Empleado empleado) //datos para la búsqueda abierta
        {

            empleado.Nomnre = empleado.Nomnre == null ? "" : empleado.Nomnre;
           

            Telcel.R9.Estructura.Result result = Telcel.R9.Estructura.Empleado.GetAllNombre(empleado);
            //result= BL.Materia.GetBusquedaAbierta();
            empleado.Empleados = result.Objects;
            return View(empleado);

        }
        public ActionResult Form(int? EmpleadoId)
        {
            Telcel.R9.Estructura.Empleado empleado = new Telcel.R9.Estructura.Empleado();

            Telcel.R9.Estructura.Result resultpuesto = Telcel.R9.Estructura.Empleado.GetAllEF();
            empleado.puesto = new Telcel.R9.Estructura.Puesto();
            empleado.puesto.Puestos = resultpuesto.Objects;

            if (EmpleadoId == null)//Add
            {
                return View(empleado);
            }
            else
            {
                ViewBag.Message = resultpuesto.ErrorMessage;
                return PartialView("Modal");
            }
        }

        public ActionResult Form(Telcel.R9.Estructura.Empleado empleado)
        {
            // ML.Materia materia = new ML.Materia();
            Telcel.R9.Estructura.Result result = new Telcel.R9.Estructura.Result();

            if (empleado.EmpleadoId == 0)//Add
            {
                result = Telcel.R9.Estructura.Empleado.AddEF(empleado);
                ViewBag.Message = "El usuario se agregó correctamente ";
            }
          
            else 
                if(!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el usuario " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }


        [HttpGet]
        public ActionResult Delete(int EmpleadoId)
        {
            Telcel.R9.Estructura.Empleado empleado = new Telcel.R9.Estructura.Empleado();
            empleado.EmpleadoId = EmpleadoId;
            Telcel.R9.Estructura.Result result = Telcel.R9.Estructura.Empleado.DeleteEF(empleado);
           

            return RedirectToAction("GetAll");
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}