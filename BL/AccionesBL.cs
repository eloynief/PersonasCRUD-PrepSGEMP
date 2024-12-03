using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AccionesBL
    {
        /// <summary>
        /// regla de negocios de crear persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static bool CrearPersonaBL(Persona persona)
        {
            return Acciones.CrearPersonaDAL(persona);
        }



        /// <summary>
        /// regla de negocios de la edicion de persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static bool EditarPersonaBL(Persona persona)
        {

            return Acciones.EditarPersonaDAL(persona);

        }


        /// <summary>
        /// regla de negocios de borrar la persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeletePersonaBL(int id)
        {



            return DAL.Acciones.DeletePersonaDAL(id);
        }






    }
}
