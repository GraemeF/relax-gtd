using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    public class InputViewPresenter : Presenter, IInputViewPresenter
    {
        private readonly IWorkspace _workspace;

        public InputViewPresenter(IWorkspace workspace, IAction newAction)
        {
            _workspace = workspace;
            Action = newAction;
            Action.ActionState = State.Inbox;
        }

        public IAction Action { get; private set; }

        public void Add()
        {
            _workspace.Add(Action);
            Shutdown();
        }
    }
}