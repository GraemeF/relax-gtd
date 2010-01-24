using System.Collections.ObjectModel;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Filters.Interfaces
{
    public interface IActionsFilter
    {
        ObservableCollection<IAction> Actions { get; }
    }
}