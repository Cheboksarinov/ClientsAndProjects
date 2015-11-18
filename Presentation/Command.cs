using System;
using System.Windows.Input;

namespace Presentation {
    public class Command : ICommand {
        private readonly Action action;
        private readonly Func<bool> canExecute;

        public Command(Action action, Func<bool> canExecute = null) {
            this.action = action;
            this.canExecute = canExecute ?? (() => true);
        }
        public void Execute(object parameter) {
            action();
        }

        public bool CanExecute(object parameter) {
            return canExecute();
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}