using System.ComponentModel.Composition;
using System.Windows.Input;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IDoNowPresenter))]
    [Export(typeof (IActionProcessorPresenter))]
    public class DoNowPresenter : Presenter, IDoNowPresenter
    {
        [ImportingConstructor]
        public DoNowPresenter(DoNowCommand applyCommand)
        {
            ApplyCommand = applyCommand;
        }

        #region IDoNowPresenter Members

        public ICommand ApplyCommand { get; private set; }

        #endregion
    }
}