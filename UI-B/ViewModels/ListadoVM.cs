using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_B.ViewModels
{
    class ListadoVM:BaseViewModel
    {
        public ObservableCollection<Persona> Personas { get; } = new();

        public ListadoVM()
        {
            // Cargar datos simulados
            Personas.Add(new Persona { Id = 1, Nombre = "Juan", Apellido = "Pérez"});
            Personas.Add(new Persona { Id = 2, Nombre = "Ana", Apellido = "López" });
        }
    }
}
