using System.Windows.Input;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Commands;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest("Do Later", typeof (IActionProcessorPresenter))]
    public class DoLaterPresenter : Presenter, IDoLaterPresenter
    {
        public DoLaterPresenter(DoLaterCommand applyCommand,
                                IContextsPresenter contextsPresenter,
                                IActionDetailsPresenter actionDetailsPresenter,
                                IProjectsPresenter projectsPresenter)
        {
            ApplyCommand = applyCommand;
            Contexts = contextsPresenter;
            Details = actionDetailsPresenter;
            Projects = projectsPresenter;
        }

        #region IDoLaterPresenter Members

        public IContextsPresenter Contexts { get; private set; }
        public IActionDetailsPresenter Details { get; private set; }
        public IProjectsPresenter Projects { get; private set; }
        public ICommand ApplyCommand { get; private set; }

        #endregion
    }
}