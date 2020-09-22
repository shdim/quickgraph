using System;
using System.Collections.Generic;

namespace QuickGraph
{
    public interface IImplicitUndirectedGraph<TVertex, TEdge>
        : IImplicitVertexSet<TVertex>
        , IGraph<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
    {
        EdgeEqualityComparer<TVertex, TEdge> EdgeEqualityComparer { get; }

        IEnumerable<TEdge> AdjacentEdges(TVertex v);

        int AdjacentDegree(TVertex v);

        bool IsAdjacentEdgesEmpty(TVertex v);

        TEdge AdjacentEdge(TVertex v, int index);

        bool TryGetEdge(TVertex source, TVertex target, out TEdge edge);

        bool ContainsEdge(TVertex source, TVertex target);
    }
}
