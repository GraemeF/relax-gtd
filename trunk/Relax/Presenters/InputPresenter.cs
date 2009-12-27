using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Filters;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IInputPresenter))]
    public class InputPresenter : Presenter, IInputPresenter
    {
        private readonly IWorkspace _workspace;

        public InputPresenter(IWorkspace workspace, IAction newAction)
        {
            _workspace = workspace;
            Action = newAction;
            Action.ActionState = State.Inbox;
        }

        public IAction Action { get; private set; }

        [Preview("CanAdd")]
        [Dependencies("Action.Title")]
        public void Add()
        {
            _workspace.Add(Action);
            Shutdown();
        }

        public bool CanAdd()
        {
            return Action.Title != string.Empty;
        }
    }
}