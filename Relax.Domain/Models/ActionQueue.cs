using System.Collections.ObjectModel;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [PerRequest(typeof (IActionQueue))]
    public class ActionQueue : ObservableCollection<IAction>, IActionQueue
    {
    }
}