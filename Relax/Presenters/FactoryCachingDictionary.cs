using System;
using System.Collections.Generic;
using Relax.Presenters.Interfaces;

namespace Relax.Presenters
{
    public class FactoryCachingDictionary<TParameter, TItem> : ICachingDictionary<TParameter, TItem>
    {
        private readonly Func<TParameter, TItem> _factory;
        private readonly Dictionary<TParameter, TItem> _items = new Dictionary<TParameter, TItem>();

        public FactoryCachingDictionary(Func<TParameter, TItem> factory)
        {
            _factory = factory;
        }

        #region ICachingDictionary<TParameter,TItem> Members

        public TItem GetOrCreate(TParameter parameter)
        {
            TItem item;
            if (!_items.TryGetValue(parameter, out item))
            {
                item = _factory(parameter);
                _items[parameter] = item;
            }

            return item;
        }

        #endregion
    }
}