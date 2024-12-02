using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ZZZ_CRUD_MAUI.ViewModels
{




    public class PersonasViewModel : BaseViewModel
    {
        private readonly ObservableCollection<Persona> _personas;
        private Persona _personaSeleccionada;

        public PersonasViewModel()
        {
            // Inicialización de las operaciones CRUD
            CrearPersonaCommand = new Command(CrearPersona);
            ActualizarPersonaCommand = new Command(ActualizarPersona);
            EliminarPersonaCommand = new Command(EliminarPersona);
            _personas = new ObservableCollection<Persona>();
            CargarPersonas();
        }

        // Lista de personas
        public ObservableCollection<Persona> Personas => _personas;

        // Persona seleccionada
        public Persona PersonaSeleccionada
        {
            get => _personaSeleccionada;
            set
            {
                _personaSeleccionada = value;
                OnPropertyChanged();  // Notifica la vista cuando cambia la propiedad
            }
        }

        // Comandos de CRUD
        public ICommand CrearPersonaCommand { get; }
        public ICommand ActualizarPersonaCommand { get; }
        public ICommand EliminarPersonaCommand { get; }

        // Funciones CRUD
        private void CargarPersonas()
        {
            // Añadir algunas personas de ejemplo
            _personas.Add(new Persona(1, "Juan", "Pérez", new DateTime(1985, 5, 12), "Calle Ficticia 123", "foto1.jpg", "123456789", 1));
            _personas.Add(new Persona(2, "Ana", "Gómez", new DateTime(1990, 8, 19), "Calle Ejemplo 456", "foto2.jpg", "987654321", 2));
        }

        private void CrearPersona()
        {
            // Lógica para crear una nueva persona
            var nuevaPersona = new Persona
            {
                Id = _personas.Count + 1, // Asignar un nuevo ID
                Nombre = "Nueva Persona",
                Apellido = "Apellido",
                FechaNac = DateTime.Now,
                Direccion = "Dirección desconocida",
                Foto = "foto3.jpg",
                Telefono = "000000000",
                IdDepartamento = 1
            };
            _personas.Add(nuevaPersona);
            OnPropertyChanged(nameof(Personas));
        }

        private void ActualizarPersona()
        {
            // Lógica para actualizar una persona seleccionada
            if (PersonaSeleccionada != null)
            {
                PersonaSeleccionada.Nombre = "Nombre Actualizado";  // Ejemplo de actualización
                PersonaSeleccionada.Apellido = "Apellido Actualizado";
                OnPropertyChanged(nameof(Personas));
            }
        }

        private void EliminarPersona()
        {
            // Lógica para eliminar una persona seleccionada
            if (PersonaSeleccionada != null)
            {
                _personas.Remove(PersonaSeleccionada);
                PersonaSeleccionada = null; // Limpiar la selección después de eliminar
                OnPropertyChanged(nameof(Personas));
            }
        }
    }






}
