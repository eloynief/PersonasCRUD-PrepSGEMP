using Entities;

namespace UI_MAUI.ViewModels
{
    public class PersonaConListaDepartamentos : Persona
    {
        #region atributos
        /// <summary>
        /// atributo para la lista de departamentos
        /// </summary>
        private List<Departamento> listadoDepartamentos;
        #endregion

        #region propiedades
        /// <summary>
        /// propiedad para el listado de departamentos
        /// </summary>
        public List<Departamento> ListadoDepartamentos
        {
            get { return listadoDepartamentos; }
        }
        #endregion

        #region constructores

        // Constructor sin parámetros, necesario para ASP.NET MVC
        public PersonaConListaDepartamentos()
        {
            listadoDepartamentos = BL.ListadosBL.ListadoDepartamentosBL();  // Inicializar la lista vacía
        }

        /// <summary>
        /// constructor con parametros
        /// </summary>
        /// <param name="persona"></param>
        /// <param name="listadoDepartamentos"></param>
        public PersonaConListaDepartamentos(Persona persona, List<Departamento> listadoDepartamentos) : base(persona.Id, persona.Nombre, persona.Apellido, persona.FechaNac, persona.Direccion, persona.Foto, persona.Telefono, persona.IdDepartamento)
        {
            this.listadoDepartamentos = listadoDepartamentos;
        }
        #endregion
    }
}
