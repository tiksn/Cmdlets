using System.Collections.Generic;
using System.Linq;
using TIKSN.Cmdlets.Common.Models;

namespace TIKSN.Cmdlets.Common.Helpers
{
    public static class LookopHelper
    {
        public static IEnumerable<LookupCounterItem<TKey, TValue>> GetCountableList<TKey, TValue>(ILookup<TKey, TValue> lookup)
        {
            List<LookupCounterItem<TKey, TValue>> countableItems = new List<LookupCounterItem<TKey, TValue>>();

            foreach (var item in lookup)
            {
                countableItems.Add(new LookupCounterItem<TKey, TValue>(item.Key, item.Count(), item));
            }

            return countableItems;
        }
    }
}