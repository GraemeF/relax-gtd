using System;
using System.Windows.Input;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Commands
{
    public abstract class ActionCommand : ICommand
    {
        public void Execute(object parameter)
        {
            Execute((IAction)parameter);
        }

        protected abstract void Execute(IAction action);

        public bool CanExecute(object parameter)
        {
            return parameter is IAction;
        }

        public event EventHandler CanExecuteChanged;
    }
}