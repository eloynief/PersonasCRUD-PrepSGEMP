using Entities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UI_MAUI.ViewModels
{
    public class PersonaConListaDepartamentos : INotifyPropertyChanged
    {
        #region atributos

        private Persona persona;
        /// <summary>
        /// atributo para la lista de departamentos
        /// </summary>
        private List<Departamento> listadoDepartamentos;
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        #region propiedades

        public Persona Per
        {
            get { return persona; }
            set { 
                persona = value;
                NotifyPropertyChanged();
            }
        }


        /// <summary>
        /// propiedad para el listado de departamentos
        /// </summary>
        public List<Departamento> ListadoDepartamentos
        {
            get { return listadoDepartamentos; }
            set
            {
                listadoDepartamentos = value;
                NotifyPropertyChanged();
            }
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
        public PersonaConListaDepartamentos(Persona persona, List<Departamento> listadoDepartamentos) 
        {
            this.persona = persona;
            this.listadoDepartamentos = listadoDepartamentos;
        }
        #endregion


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "Nombre")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
