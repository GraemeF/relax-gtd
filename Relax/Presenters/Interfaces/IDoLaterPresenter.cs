using Relax.Infrastructure.Models.Interfaces;
using Relax.Tests.Presenters;

namespace Relax.Presenters.Interfaces
{
    /// <summary>
    /// Presents the UI to put an action in a list for doing later.
    /// </summary>
    public interface IDoLaterPresenter : IActionProcessorPresenter
    {
        ISingleSelector<IGtdContext> Contexts { get; }
        IActionDetailsPresenter Details { get; }
        IProjectsPresenter Projects { get; }
    }
}