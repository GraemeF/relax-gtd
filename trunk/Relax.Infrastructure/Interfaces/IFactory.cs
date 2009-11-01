namespace Relax.Infrastructure.Interfaces
{
    public interface IFactory
    {
        IAction CreateAction();
        ICompletion CreateCompletion();
        IDeadline CreateDeadline();
        ICost CreateCost();
        IDeferral CreateDeferral();
        IDelegation CreateDelegation();
        IReview CreateReview();
        INotes CreateNotes();
    }
}