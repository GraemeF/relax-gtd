using System;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Commands
{
    [PerRequest(typeof (DoNowCommand))]
    public class DoNowCommand : ActionCommand
    {
        protected override void Execute(IAction action)
        {
            action.ActionState = State.Committed;
            action.CompletedDate = DateTime.UtcNow;
        }
    }
}