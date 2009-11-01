using System.Collections.ObjectModel;

namespace Relax.Infrastructure.Interfaces
{
    /// <summary>
    /// Something that can be done.
    /// </summary>
    public interface IAction : IItem
    {
        /// <summary>
        /// Actions that stop this action from being completed.
        /// </summary>
        ObservableCollection<IAction> BlockingActions { get; set; }

        IDeadline Deadline { get; set; }
        IDelegation Delegation { get; set; }
        IDeferral Deferral { get; set; }
        ICompletion Completion { get; set; }
        IReview Review { get; set; }
        INotes Notes { get; set; }
        IPriority Priority { get; set; }
        IRepetition Repetition { get; set; }
        ICost Cost { get; set; }
        State ActionState { get; set; }
        IContext Context { get; set; }
    }
}