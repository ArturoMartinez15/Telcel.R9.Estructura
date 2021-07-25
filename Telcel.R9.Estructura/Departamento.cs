using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telcel.R9.Estructura
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Descripcion { get; set; }
        public List<Object> Departamentos { get; set; }

        public static Telcel.R9.Estructura.Result GetAllEF()
        {
            Telcel.R9.Estructura.Result result = new Telcel.R9.Estructura.Result();

            try
            {

                using (Telcel.R9.Estructura.AccesoDatos.AMartinezEstructuraEntities1 context = new Telcel.R9.Estructura.AccesoDatos.AMartinezEstructuraEntities1())
                {
                    var query = context.DepartamentosGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            Telcel.R9.Estructura.Departamento departamento = new Telcel.R9.Estructura.Departamento();

                            departamento.DepartamentoId = obj.DepartamentoId;
                            departamento.Descripcion = obj.Descripcion;


                            result.Objects.Add(departamento);
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
