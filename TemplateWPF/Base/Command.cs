using System.Windows.Input;

namespace TemplateWPF.Base
{
    public class Command : ICommand
    {
        public Command(Action<object> execute, Func<object?, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public Action<object> _execute;

        public Func<object?, bool> _canExecute;

        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object? parameter) => _execute?.Invoke(parameter);

        public event EventHandler? CanExecuteChanged;
    }
}
