﻿using System;
using System.Collections.Generic;

namespace QuickGraph
{
    /// <summary>
    /// A directed graph datastructure that is efficient
    /// to traverse both in and out edges.
    /// </summary>
    /// <typeparam name="TVertex">The type of the vertex.</typeparam>
    /// <typeparam name="TEdge">The type of the edge.</typeparam>
    public interface IBidirectionalGraph<TVertex,TEdge> 
        : IVertexAndEdgeListGraph<TVertex,TEdge>
        , IBidirectionalIncidenceGraph<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
    {
    }
}
