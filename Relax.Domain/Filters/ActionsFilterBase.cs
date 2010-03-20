using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Filters
{
    public class ActionsFilterBase
    {
        private readonly IEnumerable<string> _propertiesThatCauseRefresh;
        private readonly ListCollectionView _view;
        private ListSync<IAction, IAction> _sync;

        public ActionsFilterBase(IWorkspace workspace,
                                 Predicate<object> filter,
                                 IEnumerable<string> propertiesThatCauseRefresh)
        {
            _propertiesThatCauseRefresh = propertiesThatCauseRefresh;
            Actions = new ObservableCollection<IAction>();
            _view = new ListCollectionView(workspace.Actions) {Filter = filter};

            _sync = new ListSync<IAction, IAction>(_view, Actions, WatchAction, UnwatchAction);
        }

        public ObservableCollection<IAction> Actions { get; private set; }

        private void UnwatchAction(IAction action)
        {
            action.PropertyChanged -= ActionPropertyChanged;
        }

        private IAction WatchAction(IAction action)
        {
            action.PropertyChanged += ActionPropertyChanged;
            return action;
        }

        private void ActionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_propertiesThatCauseRefresh.Contains(e.PropertyName))
                _view.Refresh();
        }
    }
}