using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day13
{
    static class ExtensionMethods
    {
        // from SO#538729
        // this method is faster because it only does one look-up
        // rather than two like this method
        //   return (dictionary.ContainsKey(key)) ? dictionary[key] : default(TValue);
        public static TValue GetValueOrDefault<TKey, TValue>
            (this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue ret;
            // Ignore return value
            dictionary.TryGetValue(key, out ret);
            return ret;
        }
    }
}
