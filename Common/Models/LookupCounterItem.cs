using System.Collections.Generic;

namespace TIKSN.Cmdlets.Common.Models
{
    public class LookupCounterItem<TKey, TValue>
    {
        public LookupCounterItem(TKey Key, int Count, IEnumerable<TValue> Values)
        {
            this.Key = Key;
            this.Count = Count;
            this.Values = Values;
        }

        public int Count { get; }
        public TKey Key { get; }
        public IEnumerable<TValue> Values { get; }
    }
}