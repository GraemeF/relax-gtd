using System.Windows.Input;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using MvvmFoundation.Wpf;
using Relax.Commands;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;
using Relax.Tests.Presenters;

namespace Relax.Presenters
{
    [PerRequest("Do Later", typeof (IActionProcessorPresenter))]
    public class DoLaterPresenter : Presenter, IDoLaterPresenter
    {
        private readonly DoLaterCommand _applyCommand;
        private PropertyObserver<ISingleSelector<IGtdContext>> _contextsObserver;
        private PropertyObserver<IProjectsPresenter> _projectsObserver;

        public DoLaterPresenter(DoLaterCommand applyCommand,
                                ISingleSelector<IGtdContext> contextsPresenter,
                                IActionDetailsPresenter actionDetailsPresenter,
                                IProjectsPresenter projectsPresenter)
        {
            Contexts = contextsPresenter;
            Details = actionDetailsPresenter;
            Projects = projectsPresenter;
            _applyCommand = applyCommand;
        }

        #region IDoLaterPresenter Members

        public ISingleSelector<IGtdContext> Contexts { get; private set; }
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
            Contexts.SelectedItem = _applyCommand.Context;
            _contextsObserver = new PropertyObserver<ISingleSelector<IGtdContext>>(Contexts).
                RegisterHandler(x => x.SelectedItem, y => _applyCommand.Context = y.SelectedItem);
        }

        private void BindProject()
        {
            Projects.CurrentItem = _applyCommand.Project;
            _projectsObserver = new PropertyObserver<IProjectsPresenter>(Projects).
                RegisterHandler(x => x.CurrentItem, y => _applyCommand.Project = y.CurrentItem);
        }
    }
}