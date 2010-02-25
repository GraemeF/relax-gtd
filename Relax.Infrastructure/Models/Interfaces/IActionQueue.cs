using System.Collections.Generic;

namespace Relax.Infrastructure.Models.Interfaces
{
    public interface IActionQueue : IEnumerable<IAction>
    {
        IAction Head { get; }
        void Requeue(IAction action);
    }
}