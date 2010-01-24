﻿using System;
using Autofac;
using Autofac.Builder;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Relax.Domain.Filters.Interfaces;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Infrastructure.Services.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [Singleton(typeof (IShellPresenter))]
    public class ShellPresenter : Navigator, IShellPresenter
    {
        private readonly IBackingStore _backingStore;
        private readonly IContainer _container;
        private IPresenter _dialogModel;
        private IInboxActionsFilter _inboxActionsFilter;

        public ShellPresenter(IContainer container, IBackingStore backingStore)
        {
            _container = container;
            _backingStore = backingStore;
        }

        public IContextsPresenter Contexts { get; private set; }
        public IActionsPresenter Actions { get; private set; }

        public IPresenter DialogModel
        {
            get { return _dialogModel; }
            private set
            {
                _dialogModel = value;
                NotifyOfPropertyChange("DialogModel");
            }
        }

        public bool IsProcessingEnabled
        {
            get { return !_inboxActionsFilter.InboxActions.IsEmpty; }
        }

        #region IShellPresenter Members

        public override void Initialize()
        {
            var builder = new ContainerBuilder();
            _backingStore.Initialize();

            builder.Register(_backingStore.Workspace);
            builder.RegisterGeneratedFactory<Func<IGtdContext, IGtdContextPresenter>>(
                new TypedService(typeof (IGtdContextPresenter)));
            builder.RegisterGeneratedFactory<Func<IGtdContext>>(new TypedService(typeof (IGtdContext)));
            builder.RegisterGeneratedFactory<Func<IInputPresenter>>(new TypedService(typeof (IGtdContext)));
            builder.RegisterGeneratedFactory<Func<IAction, IActionPresenter>>(new TypedService(typeof (IActionPresenter)));
            builder.RegisterGeneratedFactory<Func<IAction>>(new TypedService(typeof (IAction)));
            builder.RegisterGeneratedFactory<Func<IAction, IActionTreeNodePresenter>>(
                new TypedService(typeof (IActionTreeNodePresenter)));

            builder.Build(_container);

            Contexts = _container.Resolve<IContextsPresenter>();
            Actions = _container.Resolve<IActionsPresenter>();
            _inboxActionsFilter = _container.Resolve<IInboxActionsFilter>();
        }

        #endregion

        public void Save()
        {
            _backingStore.Save();
        }

        public void ShowDialog<T>(T presenter)
            where T : IPresenter, ILifecycleNotifier
        {
            presenter.WasShutdown +=
                delegate { DialogModel = null; };

            DialogModel = presenter;
        }

        public void ShowDialog<T>()
            where T : IPresenter, ILifecycleNotifier
        {
            ShowDialog(_container.Resolve<T>());
        }

        public void Open<T>() where T : IPresenter
        {
            var presenter = _container.Resolve<T>();
            this.Open(presenter);
        }

        public void AddInboxAction()
        {
            ShowDialog<IInputPresenter>();
        }

        public void GoCollect()
        {
            Open<ICollectPresenter>();
        }

        public void GoProcess()
        {
            Open<IProcessPresenter>();
        }
    }
}