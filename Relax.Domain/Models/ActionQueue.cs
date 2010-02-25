using System.Collections.ObjectModel;
using System.Linq;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [PerRequest(typeof (IActionQueue))]
    public class ActionQueue : ObservableCollection<IAction>, IActionQueue
    {
        #region IActionQueue Members

        public IAction Head
        {
            get { return this.FirstOrDefault(); }
        }

        public void Requeue(IAction action)
        {
            Remove(action);
            Add(action);
        }

        #endregion
    }
}