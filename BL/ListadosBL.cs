using DAL;
using Entities;

namespace BL
{
    public class ListadosBL
    {

        /// <summary>
        /// Funcion para la capa de negocios del listado de personas de la capa DAL
        /// Pre: nothing
        /// Post: Listado personas con regla de negoicos
        /// </summary>
        /// <returns></returns>
        public static List<Persona> ListadoPersonasBL()
        {
            return Listados.ListadoPersonasTest();
        }
        /// <summary>
        /// capa negocios de listadoDepartamentos
        /// Pre: nothing
        /// Post: Listado depts con regla de negoicos
        /// </summary>
        /// <returns></returns>
        public static List<Departamento> ListadoDepartamentosBL()
        {
            return Listados.ListadoDepartamentosAZURE();
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public static string ObtenerNombreDepartamentoBL(int idDepartamento)
        {
            return Listados.ObtenerNombreDepartamento(idDepartamento);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public static Persona ObtenerPersonaPorIdBL(int idPersona)
        {
            return Listados.ObtenerPersonaPorId(idPersona);
        }



    }
}
