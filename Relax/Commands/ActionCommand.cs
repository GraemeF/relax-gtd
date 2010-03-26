using System;
using System.Windows.Input;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Commands
{
    public abstract class ActionCommand : ICommand
    {
        #region ICommand Members

        public void Execute(object parameter)
        {
            Execute((IAction) parameter);
        }

        public bool CanExecute(object parameter)
        {
            var action = parameter as IAction;
            return action != null && CanExecute(action);
        }

        public event EventHandler CanExecuteChanged;

        #endregion

        protected abstract void Execute(IAction action);

        protected virtual bool CanExecute(IAction action)
        {
            return true;
        }
    }
}