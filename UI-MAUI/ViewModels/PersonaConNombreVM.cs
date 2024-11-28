using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UI_MAUI.ViewModels
{
    public class PersonaConNombreVM
    {

        private ObservableCollection<PersonaConNombreDepartamento> personas;

        private Persona personaSeleccionada;

        public event PropertyChangedEventHandler? PropertyChanged;


        /// <summary>
        /// Persona seleccionada
        /// </summary>
        public Persona PersonaSeleccionada
        {
            get => personaSeleccionada;
            set
            {
                if (personaSeleccionada != value)
                {
                    personaSeleccionada = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Listado de personas
        /// </summary>
        public ObservableCollection<PersonaConNombreDepartamento> Personas
        {
            get => personas;
            set
            {
                if (personas != value)
                {
                    personas = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Constructor del ViewModel
        /// </summary>
        public PersonaConNombreVM()
        {
            // Inicializar las listas con datos de la capa BL

            this.personas = new ObservableCollection<PersonaConNombreDepartamento>();
        }

        /// <summary>
        /// Notifica cambios en las propiedades para actualizar la UI
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad que cambió</param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
