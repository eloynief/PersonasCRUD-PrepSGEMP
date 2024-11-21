using Microsoft.Data.SqlClient;

namespace DAL
{

    /// <summary>
    /// clase para los enlaces de la base de datos
    /// </summary>
    public class EnlaceBBDD
    {
        /// <summary>
        /// Metodo para el enlace de la base de datos
        /// </summary>
        /// <returns></returns>
        public static string enlace(string server, string baseDatos, string usuario, string contrasena)
        {
            //enlace a la base de datos
            string enlace = $"server={server};database={baseDatos};uid={usuario};pwd={contrasena};";

            return enlace;
        }

        /// <summary>
        /// metodo para obtener la conexion a la base de datos
        /// </summary>
        /// <returns></returns>
        public static SqlConnection getConexion()
        {
            SqlConnection conexion = new SqlConnection();

            try
            {
                // Establece la cadena de conexion
                conexion.ConnectionString = enlace("eloybadat.database.windows.net", "eloybadat", "prueba", "fernandoG321");

                // Abre la conexion
                conexion.Open();
            }
            catch (Exception ex)
            {
                // Registra el error o lanza una excepción más detallada.
                throw new InvalidOperationException("No se pudo establecer la conexión a la base de datos.", ex);
            }

            return conexion;
        }

    }
}
