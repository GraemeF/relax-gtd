using System.ComponentModel;

namespace Relax.Domain.Filters.Interfaces
{
    public interface IInboxActionsFilter
    {
        ICollectionView InboxActions { get; }
    }
}