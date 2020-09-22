using System;
using System.Collections.Generic;

namespace QuickGraph.Predicates
{
#if !SILVERLIGHT
    [Serializable]
#endif
    public sealed class InDictionaryVertexPredicate<TVertex, TValue>
    {
        private readonly IDictionary<TVertex, TValue> dictionary;

        public InDictionaryVertexPredicate(
            IDictionary<TVertex,TValue> dictionary)
        {
            this.dictionary = dictionary;
        }

        public bool Test(TVertex v)
        {
            return this.dictionary.ContainsKey(v);
        }
    }
}
