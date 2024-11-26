using Entities;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class Acciones
    {



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static bool CrearPersonaDAL(Persona persona)
        {
            bool comp=false;
            SqlConnection miConexion = new SqlConnection();
            miConexion.ConnectionString = EnlaceBBDD.enlace("eloybadat.database.windows.net", "eloybadat", "prueba", "fernandoG321");

            try
            {
                miConexion.Open();

                // Creamos el comando con la consulta SQL
                SqlCommand miComando = new SqlCommand();
                miComando.CommandText = "INSERT INTO Personas (Nombre, Apellidos, FechaNacimiento, Direccion, Telefono, IDDepartamento) " +
                                        "VALUES (@Nombre, @Apellidos, @FechaNacimiento, @Direccion, @Telefono, @IDDepartamento)";
                miComando.Connection = miConexion;

                // Agregamos los parámetros al comando
                miComando.Parameters.AddWithValue("@Nombre", persona.Nombre);
                miComando.Parameters.AddWithValue("@Apellidos", persona.Apellido);
                miComando.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNac);
                miComando.Parameters.AddWithValue("@Direccion", persona.Direccion);
                miComando.Parameters.AddWithValue("@Telefono", persona.Telefono);
                miComando.Parameters.AddWithValue("@IDDepartamento", persona.IdDepartamento);

                // Ejecutamos el comando
                miComando.ExecuteNonQuery();

                miConexion.Close();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al crear la persona en la base de datos", ex);
            }
            finally
            {
                miConexion.Close();
            }

            return comp;
        }

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
                    using (SqlCommand miComando = new SqlCommand("DELETE FROM Personas WHERE ID = @id", miConexion))
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
