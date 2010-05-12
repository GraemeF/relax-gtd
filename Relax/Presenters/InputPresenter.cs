using System;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.Filters;
using Caliburn.PresentationFramework.Screens;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IInputPresenter))]
    public class InputPresenter : Screen, IInputPresenter
    {
        private readonly Func<IAction> _actionFactory;
        private readonly IWorkspace _workspace;

        private IAction _action;

        public InputPresenter(IWorkspace workspace, Func<IAction> actionFactory)
        {
            _workspace = workspace;
            _actionFactory = actionFactory;

            Action = _actionFactory();
            Action.ActionState = State.Inbox;
        }

        public IAction Action
        {
            get { return _action; }
            private set
            {
                _action = value;
                NotifyOfPropertyChange("Action");
            }
        }

        [Preview("CanAdd")]
        [Dependencies("Action.Title")]
        public void Add()
        {
            _workspace.Add(Action);
            Action = _actionFactory();
        }

        public bool CanAdd()
        {
            return Action.Title != string.Empty;
        }
    }
}