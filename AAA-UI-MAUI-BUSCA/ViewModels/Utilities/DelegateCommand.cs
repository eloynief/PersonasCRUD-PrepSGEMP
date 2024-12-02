using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AAA_UI_MAUI_BUSCA.ViewModels.Utilities
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object?> execute;
        private readonly Func<object?, bool>? canExecute;

        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Constructor que define la acción a ejecutar.
        /// </summary>
        /// <param name="execute">Acción que se ejecutará.</param>
        /// <param name="canExecute">Función que determina si el comando puede ejecutarse.</param>
        public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Indica si el comando se puede ejecutar.
        /// </summary>
        /// <param name="parameter">Parámetro opcional.</param>
        /// <returns>Verdadero si se puede ejecutar, falso en caso contrario.</returns>
        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        /// <summary>
        /// Ejecuta la acción asociada al comando.
        /// </summary>
        /// <param name="parameter">Parámetro opcional.</param>
        public void Execute(object? parameter)
        {
            execute(parameter);
        }

        /// <summary>
        /// Notifica que la capacidad de ejecución del comando ha cambiado.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
