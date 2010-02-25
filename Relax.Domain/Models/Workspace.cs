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
        public Workspace(IActionQueue processingQueue)
        {
            Actions = new ObservableCollection<IAction>();
            Contexts = new ObservableCollection<IGtdContext>();
            ReviewChecklistItems = new ObservableCollection<IReviewChecklistItem>();
            ProcessingQueue = processingQueue;
        }

        public IActionQueue ProcessingQueue { get; private set; }

        #region IWorkspace Members

        [DataMember(Order = 1)]
        public ObservableCollection<IGtdContext> Contexts { get; private set; }

        [DataMember(Order = 2)]
        public ObservableCollection<IAction> Actions { get; private set; }

        [DataMember(Order = 3)]
        public ObservableCollection<IReviewChecklistItem> ReviewChecklistItems { get; private set; }

        public void Add(IAction action)
        {
            Actions.Add(action);
        }

        #endregion
    }
}