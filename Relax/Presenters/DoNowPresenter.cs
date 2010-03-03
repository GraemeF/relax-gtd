using System;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IDoNowPresenter))]
    public class DoNowPresenter : Presenter, IDoNowPresenter
    {
        private readonly IAction _action;

        public DoNowPresenter(IAction action)
        {
            _action = action;
        }

        public void Done()
        {
            _action.ActionState = State.Committed;
            _action.CompletedDate = DateTime.UtcNow;

            Parent.Shutdown(this);
        }
    }
}