using AAA_UI_MAUI_EJ3.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AAA_UI_MAUI_EJ3.ViewModels
{
    public class CalculadoraVM : BaseViewModel
    {
        private string _pantalla;
        private double _primerNumero;
        private double _segundoNumero;
        private string _operacion;

        public string Pantalla
        {
            get => _pantalla;
            set => SetProperty(ref _pantalla, value);
        }

        public ICommand PulsarCommand { get; }
        public ICommand LimpiarCommand { get; }
        public ICommand OperarCommand { get; }

        public CalculadoraVM()
        {
            _pantalla = string.Empty;
            PulsarCommand = new DelegateCommand<string>(PulsarCommand_Execute);
            LimpiarCommand = new DelegateCommand<object>(LimpiarCommand_Execute);
            OperarCommand = new DelegateCommand<object>(OperarCommand_Execute);
        }

        private void PulsarCommand_Execute(string parametro)
        {
            Pantalla += parametro;
        }

        private void LimpiarCommand_Execute(object parameter)
        {
            Pantalla = string.Empty;
            _primerNumero = 0;
            _segundoNumero = 0;
            _operacion = string.Empty;
        }

        private void OperarCommand_Execute(object parameter)
        {
            // Realizar la operación
            if (double.TryParse(Pantalla, out _segundoNumero))
            {
                switch (_operacion)
                {
                    case "+":
                        Pantalla = (_primerNumero + _segundoNumero).ToString();
                        break;
                    case "-":
                        Pantalla = (_primerNumero - _segundoNumero).ToString();
                        break;
                    case "*":
                        Pantalla = (_primerNumero * _segundoNumero).ToString();
                        break;
                    case "/":
                        Pantalla = (_segundoNumero != 0) ? (_primerNumero / _segundoNumero).ToString() : "Error";
                        break;
                }
            }
        }
    }



}
