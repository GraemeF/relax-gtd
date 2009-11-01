using System.Collections.ObjectModel;
using Relax.Infrastructure.Interfaces;

namespace Relax.FileBackingStore.Models
{
    public interface IWorkspace
    {
        ObservableCollection<IAction> Actions { get; }
        ObservableCollection<IContext> Contexts { get; }
        ObservableCollection<IReviewChecklistItem> ReviewChecklistItems { get; }
    }
}