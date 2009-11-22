using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Relax.Infrastructure.Helpers
{
    /// <summary>
    /// Keeps one collection synchronized with another.
    /// </summary>
    /// <typeparam name="TSource">The type of the source items.</typeparam>
    /// <typeparam name="TDestination">The type of the destination items.</typeparam>
    public class CollectionSync<TSource, TDestination> : IDisposable
    {
        private readonly Func<TSource, TDestination> _destItemFactory;
        private readonly Action<TDestination> _destItemRemover;

        private readonly IList<TDestination> _destList;
        private readonly IList<TSource> _sourceList;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionSync&lt;TSource, TDestination&gt;"/> class.
        /// </summary>
        /// <param name="sourceList">The source list.</param>
        /// <param name="destList">The destination list.</param>
        /// <param name="destItemFactory">Factory method which creates a TDestination for a given TSource.</param>
        /// <param name="destItemRemover">Method called when a TDestination is removed.</param>
        public CollectionSync(IList<TSource> sourceList,
                              IList<TDestination> destList,
                              Func<TSource, TDestination> destItemFactory,
                              Action<TDestination> destItemRemover)
        {
            _destItemFactory = destItemFactory;
            _destItemRemover = destItemRemover;

            if (sourceList == null)
                throw new ArgumentNullException("sourceList");

            if (destList == null)
                throw new ArgumentNullException("destList");

            _sourceList = sourceList;
            _destList = destList;

            var notifier = _sourceList as INotifyCollectionChanged;
            if (notifier != null)
                notifier.CollectionChanged += SourceCollection_CollectionChanged;

            PopulateWithAllItems();
        }

        #region IDisposable Members

        /// <summary>
        /// Releases all resources used by an instance of the <see cref="CollectionSync" /> class.
        /// </summary>
        /// <remarks>
        /// This method calls the virtual <see cref="Dispose(bool)" /> method, passing in <strong>true</strong>, and then suppresses 
        /// finalization of the instance.
        /// </remarks>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        private void PopulateWithAllItems()
        {
            if (_destItemRemover != null)
                foreach (TDestination destItem in _destList)
                    _destItemRemover(destItem);

            _destList.Clear();

            foreach (TSource sourceItem in _sourceList)
                _destList.Add(_destItemFactory(sourceItem));
        }

        private void SourceCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    OnItemsAdded(args.NewStartingIndex, args.NewItems);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    OnItemsRemoved(args.OldStartingIndex, args.OldItems);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    OnItemsReset();
                    break;
                case NotifyCollectionChangedAction.Move:
                    OnItemsReset();
                    break;
                case NotifyCollectionChangedAction.Replace:
                    OnItemsReset();
                    break;
            }
        }

        private void OnItemsReset()
        {
            PopulateWithAllItems();
        }

        private void OnItemsRemoved(int index, ICollection items)
        {
            int itemCount = items.Count;
            for (int i = 0; i < itemCount; i++)
            {
                TDestination removed = _destList[index];
                _destList.RemoveAt(index);
                if (_destItemRemover != null)
                    _destItemRemover(removed);
            }
        }

        private void OnItemsAdded(int index, IList items)
        {
            int itemIndex = index;
            foreach (TSource item in items)
            {
                // Add to Items collection
                _destList.Insert(itemIndex, _destItemFactory(item));
                itemIndex++;
            }
        }

        /// <summary>
        /// Releases unmanaged resources before an instance of the <see cref="CollectionSync" /> class is reclaimed by garbage collection.
        /// </summary>
        /// <remarks>
        /// This method releases unmanaged resources by calling the virtual <see cref="Dispose(bool)" /> method, passing in <strong>false</strong>.
        /// </remarks>
        ~CollectionSync()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases the unmanaged resources used by an instance of the <see cref="CollectionSync" /> class and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><strong>true</strong> to release both managed and unmanaged resources; <strong>false</strong> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            var notifier = _sourceList as INotifyCollectionChanged;
            if (notifier != null)
                notifier.CollectionChanged -= SourceCollection_CollectionChanged;
        }
    }
}