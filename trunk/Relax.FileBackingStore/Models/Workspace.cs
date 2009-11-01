using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Relax.Infrastructure.Interfaces;

namespace Relax.FileBackingStore.Models
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/Relax.Modules.FileBackingStore.Models")]
    public class Workspace : IWorkspace
    {
        public Workspace()
        {
            Actions = new ObservableCollection<IAction>();
            Contexts = new ObservableCollection<IContext>();
            ReviewChecklistItems = new ObservableCollection<IReviewChecklistItem>();
        }

        #region IWorkspace Members

        [DataMember(Order = 1)]
        public ObservableCollection<IContext> Contexts { get; private set; }

        [DataMember(Order = 2)]
        public ObservableCollection<IAction> Actions { get; private set; }

        [DataMember(Order = 3)]
        public ObservableCollection<IReviewChecklistItem> ReviewChecklistItems { get; private set; }

        #endregion
    }
}