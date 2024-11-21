using Entities;

namespace UI.Models
{
    public class PersonaConNombreDepartamento : Persona
    {

        #region Atributos
        /// <summary>
        /// Atributo para la lista de personas
        /// </summary>
        private string nombreDepartamento;
        #endregion

        #region Propiedades

        /// <summary>
        /// Nombre del departamento al que pertenece la persona
        /// </summary>
        public string NombreDepartamento
        {
            get { return nombreDepartamento; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="persona">Instancia de la persona</param>
        /// <param name="nombreDepartamento">Nombre del departamento asociado</param>
        public PersonaConNombreDepartamento(Persona persona)
            : base(persona.Id, persona.Nombre, persona.Apellido, persona.FechaNac, persona.Direccion, persona.Foto, persona.Telefono, persona.IdDepartamento)
        {
            // Suponiendo que BL.ListadosBL.obtenerNombreDepartamentoBL es un método que retorna el nombre del departamento
            nombreDepartamento = BL.ListadosBL.ObtenerNombreDepartamentoBL(persona.IdDepartamento);
        }
        #endregion

    }


}