using BL;
using Entities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UI_MAUI.ViewModels
{
    public class PersonaConNombreDepartamento : Persona
    {

        #region Atributos
        private string nombreDepartamento;
        #endregion


        #region Propiedades

        /// <summary>
        /// Nombre del departamento al que pertenece la persona
        /// </summary>
        public string NombreDepartamento
        {
            get { return ListadosBL.ObtenerNombreDepartamentoBL(IdDepartamento); }
        }

        #endregion

        #region Constructores

        public PersonaConNombreDepartamento()
        {
            // Suponiendo que BL.ListadosBL.obtenerNombreDepartamentoBL es un método que retorna el nombre del departamento
            nombreDepartamento = BL.ListadosBL.ObtenerNombreDepartamentoBL(IdDepartamento);
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="persona">Instancia de la persona</param>
        /// <param name="nombreDepartamento">Nombre del departamento asociado</param>
        public PersonaConNombreDepartamento(Persona persona) {

            this.Id=persona.Id;
            this.Nombre=persona.Nombre;
            this.Apellido=persona.Apellido;
            this.Direccion=persona.Direccion;
            this.FechaNac=persona.FechaNac;
            this.Foto=persona.Foto;
            this.Telefono=persona.Telefono;
            this.IdDepartamento=persona.IdDepartamento;


            // Suponiendo que BL.ListadosBL.obtenerNombreDepartamentoBL es un método que retorna el nombre del departamento
            nombreDepartamento = BL.ListadosBL.ObtenerNombreDepartamentoBL(persona.IdDepartamento);


        }
        #endregion

    }


}