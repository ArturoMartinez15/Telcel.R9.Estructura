using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telcel.R9.Estructura
{
    public class Puesto
    {
        public int PuestoId { get; set; }
        public string Descripcion { get; set; }
        public List<Object> Puestos { get; set; }

        public static Telcel.R9.Estructura.Result GetAllEF()
        {
            Telcel.R9.Estructura.Result result = new Telcel.R9.Estructura.Result();

            try
            {

                using (Telcel.R9.Estructura.AccesoDatos.AMartinezEstructuraEntities1 context = new Telcel.R9.Estructura.AccesoDatos.AMartinezEstructuraEntities1())
                {
                    var query = context.PuestosGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            Telcel.R9.Estructura.Puesto puesto = new Telcel.R9.Estructura.Puesto();

                            puesto.PuestoId = obj.PuestoId;
                            puesto.Descripcion = obj.Descripcion;
                           

                            result.Objects.Add(puesto);
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
