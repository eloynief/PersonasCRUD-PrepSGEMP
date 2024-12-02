using AAA_UI_MAUI_EJ2.ViewModels.Utilities;
using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AAA_UI_MAUI_EJ2.ViewModels
{

    public class PersonaVM : INotifyPropertyChanged
    {
        public ObservableCollection<Persona> Personas { get; }
        public ObservableCollection<Persona> PersonasFiltradas { get; private set; }

        public ICommand EliminarCommand { get; }



        // Método que determina si el comando puede ejecutarse
        public bool CanDeletePersona(object? parameter)
        {
            // Asegúrate de que este método devuelve un valor booleano
            return PersonaSeleccionada != null; // Ejemplo: solo se puede eliminar si hay una persona seleccionada
        }


        private string textoBusqueda;
        public string TextoBusqueda
        {
            get => textoBusqueda;
            set
            {
                if (textoBusqueda != value)
                {
                    textoBusqueda = value;
                    FiltrarPersonas();
                    NotifyPropertyChanged();
                }
            }
        }

        private Persona personaSeleccionada;
        public Persona PersonaSeleccionada
        {
            get => personaSeleccionada;
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged();
                // Habilitar/deshabilitar el comando de eliminar según si se seleccionó una persona
                IsDeleteButtonEnabled = personaSeleccionada != null;
            }
        }

        private bool isDeleteButtonEnabled;
        public bool IsDeleteButtonEnabled
        {
            get => isDeleteButtonEnabled;
            set
            {
                isDeleteButtonEnabled = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PersonaVM()
        {
            // Cargar la lista inicial de personas (esto debería venir de tu lógica de negocio)
            Personas = new ObservableCollection<Persona>(ListadosBL.ListadoPersonasBL());
            PersonasFiltradas = new ObservableCollection<Persona>(Personas);


            // En el constructor de tu ViewModel o donde crees el DelegateCommand
            EliminarCommand = new DelegateCommand<object?>(
                        execute: EliminarPersona,
                canExecute: CanDeletePersona
            );



        }














        private void FiltrarPersonas()
        {
            if (string.IsNullOrEmpty(TextoBusqueda))
            {
                PersonasFiltradas = new ObservableCollection<Persona>(Personas);
            }
            else
            {
                var textoBusquedaLower = TextoBusqueda.ToLower();
                var listaFiltrada = Personas
                    .Where(p => p.Nombre.ToLower().Contains(textoBusquedaLower) ||
                               p.Apellido.ToLower().Contains(textoBusquedaLower))
                    .ToList();
                PersonasFiltradas = new ObservableCollection<Persona>(listaFiltrada);
            }
            NotifyPropertyChanged(nameof(PersonasFiltradas));
        }

        private void EliminarPersona(object parameter)
        {
            if (PersonaSeleccionada != null)
            {
                // Preguntar si realmente desea eliminar a la persona seleccionada
                bool confirmacion = ConfirmarEliminacion();
                if (confirmacion)
                {
                    Personas.Remove(PersonaSeleccionada);
                    PersonasFiltradas.Remove(PersonaSeleccionada); // Asegurarse de actualizar la lista filtrada también
                    PersonaSeleccionada = null; // Deseleccionar la persona
                }
            }
        }

        private bool ConfirmarEliminacion()
        {
            // Lógica para mostrar un mensaje de confirmación (puede ser un diálogo)
            // Aquí sólo retornamos true para simplificar, pero puedes agregar la lógica de confirmación real.
            return true;
        }

        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
