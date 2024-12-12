using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Listados
    {

        #region funciones de todo el listado de BBDD 
        /// <summary>
        /// Función para obtener el listado de personas de la base de datos
        /// </summary>
        /// <returns></returns>

        private static SqlCommand miComando = new SqlCommand();
        private static SqlDataReader miLector;



        public static List<Persona> ListadoPersonasTest()
        {  
            List<Persona> lista = new List<Persona>    {
                new Persona(1, "Juan", "Pérez", new DateTime(1990, 5, 21), "Calle Falsa 123", "https://via.placeholder.com/60", "123456789", 1),
                new Persona(2, "María", "López", new DateTime(1985, 7, 14), "Avenida Siempreviva 742", "https://via.placeholder.com/60", "987654321", 2),
                new Persona(3, "Carlos", "García", new DateTime(2000, 1, 10), "Boulevard del Sol 456", "https://via.placeholder.com/60", "456123789", 3)
            };
            return lista; 
        }


        public static List<Persona> ListadoPersonasAZURE()
        {
            SqlConnection miConexion = new SqlConnection();

            //se crea la lista de personas
            List<Persona> listado = new List<Persona>();


            Persona oPersona;




            miConexion.ConnectionString = EnlaceBBDD.enlace("eloynievesiesnervionbase.database.windows.net", "eloybbdd", "prueba", "fernandoG321");
            try
            {
                miConexion.Open();
                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)
                miComando.CommandText = "SELECT * FROM personas";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)

                {

                    while (miLector.Read())

                    {

                        oPersona = new Persona
                        {
                            Id = (int)miLector["ID"],
                            Nombre = miLector["Nombre"] != DBNull.Value ? (string)miLector["Nombre"] : string.Empty,
                            Apellido = miLector["Apellidos"] != DBNull.Value ? (string)miLector["Apellidos"] : string.Empty,
                            FechaNac = miLector["FechaNacimiento"] != DBNull.Value ? (DateTime)miLector["FechaNacimiento"] : DateTime.Now,
                            Direccion = miLector["Direccion"] != DBNull.Value ? (string)miLector["Direccion"] : string.Empty,
                            Foto = miLector["Foto"] != DBNull.Value ? (string)miLector["Foto"] : string.Empty,
                            Telefono = miLector["Telefono"] != DBNull.Value ? (string)miLector["Telefono"] : string.Empty,
                            IdDepartamento = miLector["IDDepartamento"] != DBNull.Value ? (int)miLector["IDDepartamento"] : 0
                        };

                        listado.Add(oPersona);
                    }

                    miLector.Close();

                    miConexion.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                miConexion.Close();
            }
            return listado;
        }



        /// <summary>
        /// Función para obtener el listado de departamentos de la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<Departamento> ListadoDepartamentosAZURE()
        {
            // Se crea la lista de departamentos
            List<Departamento> listado = new List<Departamento>();
            SqlConnection miConexion = new SqlConnection();

            miConexion.ConnectionString = EnlaceBBDD.enlace("eloynievesiesnervionbase.database.windows.net", "eloybbdd", "prueba", "fernandoG321");

            try
            {
                miConexion.Open();

                // Creamos el comando
                SqlCommand miComando = new SqlCommand();
                miComando.CommandText = "SELECT * FROM Departamentos";
                miComando.Connection = miConexion;

                // Ejecutamos el comando y obtenemos el lector
                SqlDataReader miLector = miComando.ExecuteReader();

                // Si hay filas, las leemos y las añadimos a la lista
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        Departamento oDepartamento = new Departamento
                        {
                            Id = (int)miLector["ID"],
                            Nombre = (string)miLector["Nombre"]
                        };

                        listado.Add(oDepartamento);
                    }
                }

                // Cerramos el lector y la conexión
                miLector.Close();
                miConexion.Close();

            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes registrar el error aquí si es necesario
                //throw ex;
            }
            finally
            {
                miConexion.Close();
            }

            return listado;
        }




        #endregion


        #region Funciones específicas de BBDD

        /// <summary>
        /// Función para obtener el nombre del departamento en función del ID,
        /// utilizando la función ListadoDepartamentos.
        /// </summary>
        /// <param name="idDepartamento">ID del departamento</param>
        /// <returns>Nombre del departamento, o cadena vacía si no se encuentra</returns>
        public static string ObtenerNombreDepartamento(int idDepartamento)
        {
            try
            {
                // Obtener el listado de todos los departamentos
                List<Departamento> listadoDepartamentos = ListadoDepartamentosAZURE();

                // Buscar el departamento con el ID proporcionado
                Departamento departamento = listadoDepartamentos.FirstOrDefault(d => d.Id == idDepartamento);

                // Si se encuentra el departamento, devolver su nombre; si no, devolver cadena vacía
                return departamento?.Nombre ?? string.Empty;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o propagación
                throw new Exception($"Error al obtener el nombre del departamento con ID {idDepartamento}", ex);
            }
        }


        /// <summary>
        /// Función para obtener una persona de la lista de personas en función de su ID
        /// </summary>
        /// <param name="idPersona">ID de la persona a buscar</param>
        /// <returns>Objeto Persona correspondiente al ID, o null si no se encuentra</returns>
        public static Persona ObtenerPersonaPorId(int idPersona)
        {
            try
            {
                // Llamamos a la función que devuelve la lista completa de personas
                List<Persona> listadoPersonas = ListadoPersonasAZURE();

                // Buscamos la persona cuyo ID coincida con el proporcionado
                Persona personaEncontrada = listadoPersonas.FirstOrDefault(p => p.Id == idPersona);

                return personaEncontrada; // Devuelve la persona encontrada o null si no existe
            }
            catch (Exception ex)
            {
                // Manejo de la excepción, registro o re-lanzamiento
                throw new Exception("Error al intentar obtener la persona desde el listado", ex);
            }
        }

        #endregion


    }
}
