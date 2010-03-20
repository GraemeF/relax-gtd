using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Presenters
{
    [Export(typeof (DoNowCommand))]
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

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

        #endregion
    }
}