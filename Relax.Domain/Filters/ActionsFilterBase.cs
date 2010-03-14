using System;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Relax.Infrastructure.Helpers;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Filters
{
    public class ActionsFilterBase
    {
        private ListSync<IAction, IAction> _sync;

        public ActionsFilterBase(IWorkspace workspace, Predicate<object> filter)
        {
            Actions = new ObservableCollection<IAction>();
            var view = new ListCollectionView(workspace.Actions) {Filter = filter};

            _sync = new ListSync<IAction, IAction>(view, Actions, x => x, null);
        }

        public ObservableCollection<IAction> Actions { get; private set; }
    }
}