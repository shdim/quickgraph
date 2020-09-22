﻿using System;
using System.Collections.Generic;

namespace QuickGraph
{
    /// <summary>
    /// A mutable vertex set
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    public interface IMutableVertexSet<TVertex>
        : IVertexSet<TVertex>
    {
        event VertexAction<TVertex> VertexAdded;
        bool AddVertex(TVertex v);
        int AddVertexRange(IEnumerable<TVertex> vertices);

        event VertexAction<TVertex> VertexRemoved;
        bool RemoveVertex(TVertex v);
        int RemoveVertexIf(VertexPredicate<TVertex> pred);
    }
}
