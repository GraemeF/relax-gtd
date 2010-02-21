using System.Collections.ObjectModel;

namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// Something that can be done.
    /// </summary>
    public interface IAction : IItem, IPriority, ICompletable, IDeadline, IDeferral, ICost
    {
        /// <summary>
        /// Actions that stop this action from being completed.
        /// </summary>
        ObservableCollection<IAction> BlockingActions { get; }

        IDelegation Delegation { get; set; }
        IReview Review { get; set; }
        ObservableCollection<INote> Notes { get; }
        IRepetition Repetition { get; set; }
        State ActionState { get; set; }
        IGtdContext Context { get; set; }
    }
}