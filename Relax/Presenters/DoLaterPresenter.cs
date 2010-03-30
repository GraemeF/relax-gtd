using System.Windows.Input;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using MvvmFoundation.Wpf;
using Relax.Commands;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest("Do Later", typeof (IActionProcessorPresenter))]
    public class DoLaterPresenter : Presenter, IDoLaterPresenter
    {
        private readonly DoLaterCommand _applyCommand;
        private PropertyObserver<IContextsPresenter> _contextsObserver;
        private PropertyObserver<IProjectsPresenter> _projectsObserver;

        public DoLaterPresenter(DoLaterCommand applyCommand,
                                IContextsPresenter contextsPresenter,
                                IActionDetailsPresenter actionDetailsPresenter,
                                IProjectsPresenter projectsPresenter)
        {
            Contexts = contextsPresenter;
            Details = actionDetailsPresenter;
            Projects = projectsPresenter;
            _applyCommand = applyCommand;
        }

        #region IDoLaterPresenter Members

        public IContextsPresenter Contexts { get; private set; }
        public IActionDetailsPresenter Details { get; private set; }
        public IProjectsPresenter Projects { get; private set; }

        public ICommand ApplyCommand
        {
            get { return _applyCommand; }
        }

        #endregion

        protected override void OnInitialize()
        {
            base.OnInitialize();

            BindContext();
            BindProject();
        }

        private void BindContext()
        {
            Contexts.CurrentItem = _applyCommand.Context;
            _contextsObserver = new PropertyObserver<IContextsPresenter>(Contexts).
                RegisterHandler(x => x.CurrentItem, y => _applyCommand.Context = y.CurrentItem);
        }

        private void BindProject()
        {
            Projects.CurrentItem = _applyCommand.Project;
            _projectsObserver = new PropertyObserver<IProjectsPresenter>(Projects).
                RegisterHandler(x => x.CurrentItem, y => _applyCommand.Project = y.CurrentItem);
        }
    }
}