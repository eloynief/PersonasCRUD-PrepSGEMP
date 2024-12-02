using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZZZ_CRUD_MAUI.ViewModels.Utilities;

namespace ZZZ_CRUD_MAUI.ViewModels
{
    public class PersonaVM : BindableObject
    {
        private Persona _persona;
        private ObservableCollection<Departamento> _departamentos;
        private Departamento _selectedDepartamento;

        public PersonaVM()
        {
            _departamentos = new ObservableCollection<Departamento>();
            EditarPersonaCommand = new Command(async () => await EditarPersonaAsync());
            LoadDepartamentosCommand = new Command(async () => await LoadDepartamentosAsync());
        }

        public Persona Persona
        {
            get => _persona;
            set
            {
                _persona = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Departamento> Departamentos
        {
            get => _departamentos;
            set
            {
                _departamentos = value;
                OnPropertyChanged();
            }
        }

        public Departamento SelectedDepartamento
        {
            get => _selectedDepartamento;
            set
            {
                _selectedDepartamento = value;
                OnPropertyChanged();
            }
        }

        public ICommand EditarPersonaCommand { get; }
        public ICommand LoadDepartamentosCommand { get; }

        public async Task LoadDepartamentosAsync()
        {
            // Simulando la carga de datos desde la base de datos (local)
            var departamentos = await Task.Run(() =>
            {
                return ListadosBL.ListadoDepartamentosBL();
            });

            Departamentos.Clear();
            foreach (var depto in departamentos)
            {
                Departamentos.Add(depto);
            }
        }

        public async Task EditarPersonaAsync()
        {
            if (SelectedDepartamento != null)
            {
                Persona.IdDepartamento = SelectedDepartamento.Id;
            }

            // Llamamos a la lógica de negocio para editar la persona
            bool result = await Task.Run(() => AccionesBL.EditarPersonaBL(Persona));

            if (result)
            {
                // Lógica adicional después de editar, como notificar al usuario
            }
        }
    }
}
