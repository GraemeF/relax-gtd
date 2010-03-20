using System.ComponentModel.Composition;
using System.Windows.Input;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    /// <summary>
    /// Presents the UI allowing the action being processed to be marked as done.
    /// </summary>
    [Export(typeof (IActionProcessorPresenter))]
    public class DoNowPresenter : Presenter, IActionProcessorPresenter
    {
        [ImportingConstructor]
        public DoNowPresenter(DoNowCommand applyCommand)
        {
            ApplyCommand = applyCommand;
        }

        #region IActionProcessorPresenter Members

        public ICommand ApplyCommand { get; private set; }

        #endregion
    }
}