using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Presenters
{
    [Export(typeof(DoNowCommand))]
    public class DoNowCommand : ICommand
    {
        #region ICommand Members

        public void Execute(object parameter)
        {
            var action = (IAction) parameter;
            action.ActionState = State.Committed;
            action.CompletedDate = DateTime.UtcNow;
        }

        public bool CanExecute(object parameter)
        {
            return parameter is IAction;
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}