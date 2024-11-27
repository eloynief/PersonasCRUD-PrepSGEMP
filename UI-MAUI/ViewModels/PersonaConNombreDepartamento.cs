using Entities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UI_MAUI.ViewModels
{
    public class PersonaConNombreDepartamento : INotifyPropertyChanged
    {

        #region Atributos
        private Persona persona;
        /// <summary>
        /// Atributo para la lista de personas
        /// </summary>
        private string nombreDepartamento;
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        #region Propiedades

        public Persona Per
        {
            get { return persona; }
            set
            {
                persona = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Nombre del departamento al que pertenece la persona
        /// </summary>
        public string NombreDepartamento
        {
            get { return nombreDepartamento; }
        }

        #endregion

        #region Constructores

        public PersonaConNombreDepartamento()
        {

        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="persona">Instancia de la persona</param>
        /// <param name="nombreDepartamento">Nombre del departamento asociado</param>
        public PersonaConNombreDepartamento(Persona persona) {

            // Suponiendo que BL.ListadosBL.obtenerNombreDepartamentoBL es un método que retorna el nombre del departamento
            nombreDepartamento = BL.ListadosBL.ObtenerNombreDepartamentoBL(persona.IdDepartamento);


        }
        #endregion

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "Nombre")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
 
    }


}