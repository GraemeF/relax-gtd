using System.Windows.Input;
using Caliburn.PresentationFramework.Screens;

namespace Relax.Presenters.Interfaces
{
    public interface IActionProcessorPresenter : IScreen
    {
        ICommand ApplyCommand { get; }
    }
}