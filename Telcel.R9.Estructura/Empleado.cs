using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telcel.R9.Estructura
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nomnre { get; set; }

        public Telcel.R9.Estructura.Puesto puesto {get; set ;}

        public Telcel.R9.Estructura.Departamento departamento { get; set; }
        public List<Object> Empleados { get; set; }

        public static Telcel.R9.Estructura.Result GetAllEF()
        {
            Telcel.R9.Estructura.Result result = new Telcel.R9.Estructura.Result();

            try
            {

                using (Telcel.R9.Estructura.AccesoDatos.AMartinezEstructuraEntities1 context = new Telcel.R9.Estructura.AccesoDatos.AMartinezEstructuraEntities1())
                {
                    var query = context.EmpleadosPuestosGetAll() .ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            Telcel.R9.Estructura.Empleado empleado = new Telcel.R9.Estructura.Empleado();

                            empleado.Nomnre = obj.NombreEmpleado;
                            empleado.puesto = new Telcel.R9.Estructura.Puesto();
                            empleado.puesto.Descripcion = obj.DescripcionPuesto;
                            empleado.departamento = new Telcel.R9.Estructura.Departamento();
                            empleado.departamento.Descripcion = obj.DescripcionDepartamento;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "NO se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }

        public static Telcel.R9.Estructura.Result AddEF(Telcel.R9.Estructura.Empleado empleado)
        {
            Telcel.R9.Estructura.Result result = new Telcel.R9.Estructura.Result();

            try
            {

                using (Telcel.R9.Estructura.AccesoDatos.AMartinezEstructuraEntities1 context = new Telcel.R9.Estructura.AccesoDatos.AMartinezEstructuraEntities1())
                {

                    var query = context.EmpleadoAdd(empleado.Nomnre,empleado.puesto.PuestoId,empleado.departamento.DepartamentoId);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto el registro";
                    }

                    return result;
                }

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


        public static Telcel.R9.Estructura.Result DeleteEF(Telcel.R9.Estructura.Empleado empleado)
        {
            Telcel.R9.Estructura.Result result = new Telcel.R9.Estructura.Result();

            try
            {

                using (Telcel.R9.Estructura.AccesoDatos.AMartinezEstructuraEntities1 context = new Telcel.R9.Estructura.AccesoDatos.AMartinezEstructuraEntities1())
                {
                    var query = context.EmpleadoDelete(empleado.EmpleadoId);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino el registro";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static Telcel.R9.Estructura.Result GetAllNombre(Telcel.R9.Estructura.Empleado empleado)
        {
            Telcel.R9.Estructura.Result result = new Telcel.R9.Estructura.Result();

            try
            {

                using (Telcel.R9.Estructura.AccesoDatos.AMartinezEstructuraEntities1 context = new Telcel.R9.Estructura.AccesoDatos.AMartinezEstructuraEntities1())
                {
                    var query = context.NombreEmpleadoCoincidenciaGetAll(empleado.Nomnre).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {

                            empleado.EmpleadoId = obj.EmpleadoId;
                            empleado.Nomnre = obj.Nombre;
                            empleado.puesto = new Telcel.R9.Estructura.Puesto();
                            empleado.puesto.PuestoId= obj.PuestoId.Value;
                            empleado.departamento = new Telcel.R9.Estructura.Departamento();
                            empleado.departamento.DepartamentoId = obj.DepartamentoId.Value;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "NO se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }

    }
}
