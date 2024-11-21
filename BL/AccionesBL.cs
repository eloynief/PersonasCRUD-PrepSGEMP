using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AccionesBL
    {


        public static int DeletePersonaBL(int id)
        {
            return DAL.Acciones.DeletePersonaDAL(id);
        }






    }
}
