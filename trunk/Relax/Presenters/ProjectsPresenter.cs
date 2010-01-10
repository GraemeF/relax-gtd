using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Caliburn.Core.Metadata;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    [PerRequest(typeof (IProjectsPresenter))]
    public class ProjectsPresenter : ListPresenter<IAction, IHierarchicalActionPresenter>, IProjectsPresenter
    {
        public ProjectsPresenter(IWorkspace workspace,
                                 Func<IAction, IHierarchicalActionPresenter> actionPresenterFactory)
            : base(GetFilteredView(workspace.Actions), actionPresenterFactory)
        {
        }

        private static ICollectionView GetFilteredView(ObservableCollection<IAction> actions)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(actions);
            view.Filter =
                action =>
                ((IAction) action).BlockingActions.Any() &&
                !actions.Any(x => x.BlockingActions.Contains((IAction) action));

            return view;
        }
    }
}