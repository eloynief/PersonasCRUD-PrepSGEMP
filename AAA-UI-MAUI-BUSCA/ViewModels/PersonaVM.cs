using AAA_UI_MAUI_BUSCA.ViewModels.Utilities;
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

namespace AAA_UI_MAUI_BUSCA.ViewModels
{
    public class PersonaVM : INotifyPropertyChanged
    {
        public ObservableCollection<Persona> Personas { get; }
        public DelegateCommand BuscarCommand { get; }

        private string textoBusqueda;
        public string TextoBusqueda
        {
            get => textoBusqueda;
            set
            {
                if (textoBusqueda != value)
                {
                    textoBusqueda = value;
                    BuscarCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private ObservableCollection<Persona> personasFiltradas;
        public ObservableCollection<Persona> PersonasFiltradas
        {
            get => personasFiltradas;
            private set
            {
                personasFiltradas = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PersonaVM()
        {
            // Inicializar las personas desde la capa BL
            Personas = new ObservableCollection<Persona>(ListadosBL.ListadoPersonasBL());
            PersonasFiltradas = new ObservableCollection<Persona>(Personas); // Inicializa con todas las personas
            BuscarCommand = new DelegateCommand(Buscar, PuedeBuscar);
        }

        private void Buscar(object? parameter)
        {
            // Filtrar las personas según el texto de búsqueda
            var textoBusquedaLower = TextoBusqueda.ToLower();
            var listaFiltrada = Personas
                .Where(p => p.Nombre.ToLower().Contains(textoBusquedaLower) ||
                            p.Apellido.ToLower().Contains(textoBusquedaLower))
                .ToList();

            // Actualizar la propiedad PersonasFiltradas para que la vista se actualice
            PersonasFiltradas = new ObservableCollection<Persona>(listaFiltrada);
        }

        private bool PuedeBuscar(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(TextoBusqueda);
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
