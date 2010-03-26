using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Commands
{
    [PerRequest(typeof (DoLaterCommand))]
    public class DoLaterCommand : ActionCommand
    {
        public IGtdContext Context { get; set; }

        public IAction Project { get; set; }

        protected override bool CanExecute(IAction action)
        {
            return Context != null;
        }

        protected override void Execute(IAction action)
        {
            action.ActionState = State.Committed;
            action.Context = Context;

            if (Project != null)
                Project.AddBlockingAction(action);
        }
    }
}