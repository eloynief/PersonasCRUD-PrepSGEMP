﻿using BL;
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
            get => new ObservableCollection<Persona>(ListadosBL.ListadoPersonasBL());
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

        /// <summary>
        /// Constructor del ViewModel
        /// </summary>
        public PersonaVM()
        {
            // Inicializar las listas con datos de la capa BL

            this.personas = new ObservableCollection<Persona>(ListadosBL.ListadoPersonasBL());
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
