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
    internal class PersonaVM
    {

        private ObservableCollection<Persona> personas;
        private ObservableCollection<Departamento> departamentos;
        private Persona personaSeleccionada;

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Listado de departamentos
        /// </summary>
        public ObservableCollection<Departamento> Departamentos
        {
            get => departamentos;
            set
            {
                if (departamentos != value)
                {
                    departamentos = value;
                    NotifyPropertyChanged();
                }
            }
        }

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
        public ObservableCollection<Persona> Personas
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
        public PersonaVM()
        {
            // Inicializar las listas con datos de la capa BL
            Personas = new ObservableCollection<Persona>(BL.ListadosBL.ListadoPersonasBL());
            Departamentos = new ObservableCollection<Departamento>(BL.ListadosBL.ListadoDepartamentosBL());
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
