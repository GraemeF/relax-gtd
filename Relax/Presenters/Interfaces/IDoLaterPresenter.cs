namespace Relax.Presenters.Interfaces
{
    /// <summary>
    /// Presents the UI to put an action in a list for doing later.
    /// </summary>
    public interface IDoLaterPresenter : IActionProcessorPresenter
    {
        IContextsPresenter Contexts { get; }
        IActionDetailsPresenter Details { get; }
        IProjectsPresenter Projects { get; }
    }
}