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
using System.Windows.Input;

namespace UI_MAUI.ViewModels
{
    public class PersonaVM
    {

        private ObservableCollection<Persona> personas;

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
        public ObservableCollection<Persona> Personas
        {
            get => personas;
            /**
            set
            {
                if (personas != value)
                {
                    personas = value;
                    NotifyPropertyChanged();
                }
            }
            */
        }


        // Comandos
        public ICommand GuardarPersonaCommand { get; }
        public ICommand CancelarEdicionCommand { get; }

        //botones
        public ICommand EditarPersonaCommand { get; }
        public ICommand BorrarPersonaCommand { get; }




        /// <summary>
        /// Constructor del ViewModel
        /// </summary>
        public PersonaVM()
        {
            // Inicializar las listas con datos de la capa BL

            this.personas = new ObservableCollection<Persona>(ListadosBL.ListadoPersonasBL());


            // Inicializamos los comandos con la clase personalizada
            EditarPersonaCommand = new Command(EditarPersona);
            BorrarPersonaCommand = new Command(BorrarPersona);



        }

        /// <summary>
        /// funcion para editar persona
        /// </summary>
        /// <param name="parameter"></param>
        private void EditarPersona(object parameter)
        {
            // Llama directamente a la capa BL para la edición
            if (parameter is Persona persona)
            {
                BL.AccionesBL.EditarPersonaBL(persona);
            }

        }

        private void BorrarPersona(object parameter)
        {
            // Llama directamente a la capa BL para la edición
            if (parameter is Persona persona)
            {
                BL.AccionesBL.DeletePersonaBL(persona.Id);
            }

        }



        /// <summary>
        /// Método para guardar persona
        /// </summary>
        private void GuardarPersona()
        {
            if (PersonaSeleccionada != null)
            {
                if (PersonaSeleccionada.Id == 0) // Nueva persona
                {
                    PersonaSeleccionada.Id = GenerarNuevoId();
                    Personas.Add(PersonaSeleccionada);
                }
                else // Editar persona existente
                {
                    var personaExistente = Personas.FirstOrDefault(p => p.Id == PersonaSeleccionada.Id);
                    if (personaExistente != null)
                    {
                        personaExistente.Nombre = PersonaSeleccionada.Nombre;
                        personaExistente.Apellido = PersonaSeleccionada.Apellido;
                        personaExistente.Direccion = PersonaSeleccionada.Direccion;
                        personaExistente.FechaNac = PersonaSeleccionada.FechaNac;
                        personaExistente.IdDepartamento = PersonaSeleccionada.IdDepartamento;
                    }
                }
            }

            // Limpiar selección después de guardar
            PersonaSeleccionada = null;
        }

        // Método para cancelar edición
        private void CancelarEdicion()
        {
            PersonaSeleccionada = null; // Limpia la persona seleccionada
        }

        // Generar un ID único para una nueva persona
        private int GenerarNuevoId()
        {
            return Personas.Any() ? Personas.Max(p => p.Id) + 1 : 1;
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
