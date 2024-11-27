using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UI_MAUI.ViewModels
{
    public class ListaPersonasVM : INotifyPropertyChanged
    {

        private List<Persona> personas;


        public event PropertyChangedEventHandler? PropertyChanged;


        public List<Persona> Personas
        {
            get { return BL.ListadosBL.ListadoPersonasBL(); }

            set { 
                personas = value; 
            }

        }



        public ListaPersonasVM()
        {
            try
            {
                personas = BL.ListadosBL.ListadoPersonasBL();
            }
            catch(Exception e)
            {
                //todo error
            }

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
