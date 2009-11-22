using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Models
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/Relax.Modules.FileBackingStore.Models")]
    [PerRequest(typeof (IWorkspace))]
    public class Workspace : IWorkspace
    {
        public Workspace()
        {
            Actions = new ObservableCollection<IAction>();
            Contexts = new ObservableCollection<IContext>();
            ReviewChecklistItems = new ObservableCollection<IReviewChecklistItem>();

            Contexts.Add(new Context() { Title = "Home" });
            Contexts.Add(new Context() { Title = "Office" });
            Contexts.Add(new Context() { Title = "Errands" });
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