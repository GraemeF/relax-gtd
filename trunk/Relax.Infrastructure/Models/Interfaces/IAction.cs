using System.Collections.ObjectModel;

namespace Relax.Infrastructure.Models.Interfaces
{
    /// <summary>
    /// Something that can be done.
    /// </summary>
    public interface IAction : IItem, IPriority
    {
        /// <summary>
        /// Actions that stop this action from being completed.
        /// </summary>
        ObservableCollection<IAction> BlockingActions { get; }

        IDeadline Deadline { get; set; }
        IDelegation Delegation { get; set; }
        IDeferral Deferral { get; set; }
        ICompletion Completion { get; set; }
        IReview Review { get; set; }
        ObservableCollection<INote> Notes { get; }
        IRepetition Repetition { get; set; }
        ICost Cost { get; set; }
        State ActionState { get; set; }
        IGtdContext Context { get; set; }
    }
}