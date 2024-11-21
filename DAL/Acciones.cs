using Microsoft.Data.SqlClient;

namespace DAL
{
    public class Acciones
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static int DeletePersonaDAL(int id)
        {
            int numeroFilasAfectadas = 0;

            try
            {
                // Usamos el método getConexion() para obtener la conexión.
                using (SqlConnection miConexion = EnlaceBBDD.getConexion())
                {
                    // Comando para eliminar la persona con el ID proporcionado.
                    using (SqlCommand miComando = new SqlCommand("DELETE FROM Personas WHERE IDPersona = @id", miConexion))
                    {
                        // Añadimos el parámetro para el ID de la persona a eliminar.
                        miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                        // Abrimos la conexión y ejecutamos la consulta.
                        miConexion.Open();
                        numeroFilasAfectadas = miComando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Re-lanzamos la excepción para ser manejada por el código superior.
                throw new InvalidOperationException("Error al eliminar la persona", ex);
            }

            return numeroFilasAfectadas;
        }


    }
}
