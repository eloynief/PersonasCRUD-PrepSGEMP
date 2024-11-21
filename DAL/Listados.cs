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
        public static List<Persona> ListadoPersonasAZURE()
        {
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            List<Persona> listado = new List<Persona>();
            Persona oPersona;

            try
            {
                // Usamos getConexion() para obtener la conexión
                using (SqlConnection miConexion = EnlaceBBDD.getConexion())
                {
                    // Creamos el comando para ejecutar la consulta
                    miComando.CommandText = "SELECT * FROM Personas";
                    miComando.Connection = miConexion;

                    // Ejecutamos la consulta y obtenemos los resultados
                    miLector = miComando.ExecuteReader();

                    if (miLector.HasRows)
                    {
                        while (miLector.Read())
                        {
                            oPersona = new Persona
                            {
                                Id = (int)miLector["ID"],
                                Nombre = (string)miLector["Nombre"],
                                Apellido = (string)miLector["Apellidos"],
                                FechaNac = miLector["FechaNacimiento"] != DBNull.Value ? (DateTime)miLector["FechaNacimiento"] : default,
                                Direccion = (string)miLector["Direccion"],
                                Telefono = (string)miLector["Telefono"],
                                IdDepartamento = (int)miLector["IDDepartamento"]
                            };

                            listado.Add(oPersona);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener el listado de personas", ex);
            }

            return listado;
        }





        /// <summary>
        /// Función para obtener el listado de departamentos de la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<Departamento> ListadoDepartamentosAZURE()
        {
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            List<Departamento> listado = new List<Departamento>();
            Departamento oDepartamento;

            try
            {
                // Usamos getConexion() para obtener la conexión
                using (SqlConnection miConexion = EnlaceBBDD.getConexion())
                {
                    // Creamos el comando para ejecutar la consulta
                    miComando.CommandText = "SELECT * FROM Departamentos";
                    miComando.Connection = miConexion;

                    // Ejecutamos la consulta y obtenemos los resultados
                    miLector = miComando.ExecuteReader();

                    if (miLector.HasRows)
                    {
                        while (miLector.Read())
                        {
                            oDepartamento = new Departamento
                            {
                                Id = (int)miLector["ID"],
                                Nombre = (string)miLector["Nombre"]
                            };

                            listado.Add(oDepartamento);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener el listado de departamentos", ex);
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
