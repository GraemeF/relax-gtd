using System.Collections.ObjectModel;

namespace Relax.Infrastructure.Models.Interfaces
{
    public interface IWorkspace
    {
        ObservableCollection<IAction> Actions { get; }
        ObservableCollection<IGtdContext> Contexts { get; }
        ObservableCollection<IReviewChecklistItem> ReviewChecklistItems { get; }
        void Add(IAction action);
    }
}