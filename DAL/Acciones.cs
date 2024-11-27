using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections.Generic;

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
                comp= true;
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
        /// funcion para editar la persona en la capa DAL
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static bool EditarPersonaDAL(Persona persona)
        {
            bool comp = false;
            SqlConnection miConexion = new SqlConnection();
            miConexion.ConnectionString = EnlaceBBDD.enlace("eloybadat.database.windows.net", "eloybadat", "prueba", "fernandoG321");

            try
            {
                miConexion.Open();
                // Creamos el comando con la consulta SQL
                SqlCommand miComando = new SqlCommand();
                miComando.CommandText = @"
                UPDATE Personas
                SET 
                    Nombre = @Nombre,
                    Apellido = @Apellido,
                    FechaNac = @FechaNacimiento,
                    Direccion = @Direccion,
                    Foto = @Foto,
                    Telefono = @Telefono,
                    IDDepartamento = @IDDepartamento
                WHERE IDPersona = @ID";


                miComando.Connection = miConexion;

                // Agregamos los parámetros al comando
                miComando.Parameters.AddWithValue("@Nombre", persona.Nombre);
                miComando.Parameters.AddWithValue("@Apellidos", persona.Apellido);
                miComando.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNac);
                miComando.Parameters.AddWithValue("@Direccion", persona.Direccion);
                miComando.Parameters.AddWithValue("@Telefono", persona.Telefono);
                miComando.Parameters.AddWithValue("@IDDepartamento", persona.IdDepartamento);
                miComando.Parameters.AddWithValue("@ID", persona.Id);


                // Ejecutamos el comando
                miComando.ExecuteNonQuery();

                comp = true;

                miConexion.Close();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al editar la persona en la base de datos", ex);
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
            SqlConnection miConexion = EnlaceBBDD.getConexion();
            try
            {



                // Creamos el comando con la consulta SQL
                SqlCommand miComando = new SqlCommand();

                miComando.CommandText = "DELETE FROM Personas WHERE ID = @id";

                miComando.Connection = miConexion;



                // Añadimos el parámetro para el ID de la persona a eliminar.
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;


                // Abrimos la conexión y ejecutamos la consulta.
                miConexion.Open();
                numeroFilasAfectadas = miComando.ExecuteNonQuery();
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
