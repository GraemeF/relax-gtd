using System;
using System.Collections.Generic;
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

        public ProcessActionPresenter(IAction action,
                                      Func<IAction, IEnumerable<IActionProcessorPresenter>> actionProcessors)
        {
            _action = action;
            ActionProcessors = actionProcessors(_action);

            _propertyObserver = new PropertyObserver<IAction>(Model).
                RegisterHandler(x => x.Title,
                                y => NotifyOfPropertyChange(() => DisplayName));
        }

        public IEnumerable<IActionProcessorPresenter> ActionProcessors { get; private set; }

        #region IProcessActionPresenter Members

        public override string DisplayName
        {
            get { return Model.Title; }
            set { Model.Title = value; }
        }

        public IAction Model
        {
            get { return _action; }
        }

        #endregion

        protected override void OnInitialize()
        {
            base.OnInitialize();

            OpenProcessors();
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