using System.Windows.Input;
using Caliburn.PresentationFramework.ApplicationModel;

namespace Relax.Presenters.Interfaces
{
    public interface IActionProcessorPresenter : IPresenter
    {
        ICommand ApplyCommand { get; }
    }
}