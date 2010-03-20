using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using MvvmFoundation.Wpf;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IProcessActionPresenter))]
    public class ProcessActionPresenter : MultiPresenterManager, IProcessActionPresenter
    {
        private readonly IAction _action;
        private PropertyObserver<IAction> _propertyObserver;

        public ProcessActionPresenter(IAction action)
        {
            _action = action;

            _propertyObserver = new PropertyObserver<IAction>(Model).
                RegisterHandler(x => x.Title,
                                y => NotifyOfPropertyChange(() => DisplayName));
        }

        [ImportMany]
        public IEnumerable<IActionProcessorPresenter> ActionProcessors { get; set; }

        #region IProcessActionPresenter Members

        public override string DisplayName
        {
            get { return Model.Title; }
            set { Model.Title = value; }
        }

        [Export]
        public IAction Model
        {
            get { return _action; }
        }

        #endregion

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Compose();
            OpenProcessors();
        }

        private void Compose()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        private void OpenProcessors()
        {
            foreach (IActionProcessorPresenter processor in ActionProcessors)
                this.Open(processor);
        }

        public void Apply()
        {
            var actionProcessorPresenter = (IActionProcessorPresenter) CurrentPresenter;
            actionProcessorPresenter.ApplyCommand.Execute(_action);
        }
    }
}