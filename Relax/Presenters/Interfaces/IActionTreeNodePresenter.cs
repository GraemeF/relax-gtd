namespace Relax.Presenters.Interfaces
{
    public interface IActionTreeNodePresenter : IActionPresenter
    {
        IBlockingActionsPresenter BlockingActions { get; }
    }
}