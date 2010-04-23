using System.Windows.Input;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using MvvmFoundation.Wpf;
using Relax.Commands;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest("Do Later", typeof (IActionProcessorPresenter))]
    public class DoLaterPresenter : Presenter, IDoLaterPresenter
    {
        private readonly DoLaterCommand _applyCommand;
        private PropertyObserver<ISingleSelector<IGtdContext>> _contextsObserver;
        private PropertyObserver<IOptionalProjectSelector> _projectsObserver;

        public DoLaterPresenter(DoLaterCommand applyCommand,
                                ISingleSelector<IGtdContext> contextsPresenter,
                                IActionDetailsPresenter actionDetailsPresenter,
                                IOptionalProjectSelector projectsPresenter)
        {
            Contexts = contextsPresenter;
            Details = actionDetailsPresenter;
            Projects = projectsPresenter;
            _applyCommand = applyCommand;
        }

        #region IDoLaterPresenter Members

        public override string DisplayName
        {
            get { return "Later"; }
            set { }
        }

        public ISingleSelector<IGtdContext> Contexts { get; private set; }
        public IActionDetailsPresenter Details { get; private set; }
        public IOptionalProjectSelector Projects { get; private set; }

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
            Projects.SelectedItem = _applyCommand.Project;
            _projectsObserver = new PropertyObserver<IOptionalProjectSelector>(Projects).
                RegisterHandler(x => x.SelectedItem, y => _applyCommand.Project = y.SelectedItem);
        }
    }
}