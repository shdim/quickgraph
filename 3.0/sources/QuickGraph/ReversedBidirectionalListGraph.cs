﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace QuickGraph
{
#if !SILVERLIGHT
    [Serializable]
#endif
    [DebuggerDisplay("VertexCount = {VertexCount}, EdgeCount = {EdgeCount}")]
    public sealed class ReversedBidirectionalGraph<TVertex, TEdge> : 
        IBidirectionalGraph<TVertex,SReversedEdge<TVertex,TEdge>>
        where TEdge : IEdge<TVertex>
    {
        private readonly IBidirectionalGraph<TVertex,TEdge> originalGraph;
        public ReversedBidirectionalGraph(IBidirectionalGraph<TVertex,TEdge> originalGraph)
        {
            this.originalGraph = originalGraph;
        }

        public IBidirectionalGraph<TVertex,TEdge> OriginalGraph
        {
            get { return this.originalGraph;}
        }
    
        public bool  IsVerticesEmpty
        {
        	get { return this.OriginalGraph.IsVerticesEmpty; }
        }

        public bool IsDirected
        {
            get { return this.OriginalGraph.IsDirected; }
        }

        public bool AllowParallelEdges
        {
            get { return this.OriginalGraph.AllowParallelEdges; }
        }

        public int  VertexCount
        {
        	get { return this.OriginalGraph.VertexCount; }
        }

        public IEnumerable<TVertex> Vertices
        {
        	get { return this.OriginalGraph.Vertices; }
        }

        public bool ContainsVertex(TVertex vertex)
        {
            return this.OriginalGraph.ContainsVertex(vertex);
        }   

        public bool ContainsEdge(TVertex source, TVertex target)
        {
            return this.OriginalGraph.ContainsEdge(target,source);
        }

        public bool TryGetEdge(
            TVertex source,
            TVertex target,
            out SReversedEdge<TVertex, TEdge> edge)
        {
            TEdge oedge;
            if (this.OriginalGraph.TryGetEdge(target, source, out oedge))
            {
                edge = new SReversedEdge<TVertex, TEdge>(oedge);
                return true;
            }
            else
            {
                edge = default(SReversedEdge<TVertex, TEdge>);
                return false;
            }
        }

        public bool TryGetEdges(
            TVertex source,
            TVertex target,
            out IEnumerable<SReversedEdge<TVertex,TEdge>> edges)
        {
            IEnumerable<TEdge> oedges;
            if (this.OriginalGraph.TryGetEdges(target, source, out oedges))
            {
                List<SReversedEdge<TVertex, TEdge>> list = new List<SReversedEdge<TVertex, TEdge>>();
                foreach (var oedge in oedges)
                    list.Add(new SReversedEdge<TVertex, TEdge>(oedge));
                edges = list;
                return true;
            }
            else
            {
                edges = null;
                return false;
            }
        }

        public bool IsOutEdgesEmpty(TVertex v)
        {
            return this.OriginalGraph.IsInEdgesEmpty(v);
        }

        public int OutDegree(TVertex v)
        {
            return this.OriginalGraph.InDegree(v);
        }

        public IEnumerable<SReversedEdge<TVertex, TEdge>> InEdges(TVertex v)
        {
            return EdgeExtensions.ReverseEdges<TVertex, TEdge>(this.OriginalGraph.OutEdges(v));
        }

        public SReversedEdge<TVertex, TEdge> InEdge(TVertex v, int index)
        {
            TEdge edge = this.OriginalGraph.OutEdge(v, index);
            if (edge == null)
                return default(SReversedEdge<TVertex,TEdge>);
            return new SReversedEdge<TVertex, TEdge>(edge);
        }

        public bool IsInEdgesEmpty(TVertex v)
        {
            return this.OriginalGraph.IsOutEdgesEmpty(v);
        }

        public int InDegree(TVertex v)
        {
            return this.OriginalGraph.OutDegree(v);
        }

        public IEnumerable<SReversedEdge<TVertex, TEdge>> OutEdges(TVertex v)
        {
            return EdgeExtensions.ReverseEdges<TVertex, TEdge>(this.OriginalGraph.InEdges(v));
        }

        public bool TryGetInEdges(TVertex v, out IEnumerable<SReversedEdge<TVertex, TEdge>> edges)
        {
            IEnumerable<TEdge> outEdges;
            if (this.OriginalGraph.TryGetOutEdges(v, out outEdges))
            {
                edges = EdgeExtensions.ReverseEdges<TVertex, TEdge>(outEdges);
                return true;
            }
            else
            {
                edges = null;
                return false;
            }

        }

        public bool TryGetOutEdges(TVertex v, out IEnumerable<SReversedEdge<TVertex, TEdge>> edges)
        {
            IEnumerable<TEdge> inEdges;
            if (this.OriginalGraph.TryGetInEdges(v, out inEdges))
            {
                edges = EdgeExtensions.ReverseEdges<TVertex, TEdge>(inEdges);
                return true;
            }
            else
            {
                edges = null;
                return false;
            }
        }

        public SReversedEdge<TVertex, TEdge> OutEdge(TVertex v, int index)
        {
            TEdge edge = this.OriginalGraph.InEdge(v, index);
            if (edge == null)
                return default(SReversedEdge<TVertex,TEdge>);
            return new SReversedEdge<TVertex, TEdge>(edge);
        }

        public IEnumerable<SReversedEdge<TVertex,TEdge>>  Edges
        {
        	get 
            {
                foreach(TEdge edge in this.OriginalGraph.Edges)
                    yield return new SReversedEdge<TVertex,TEdge>(edge);
            }
        }

        public bool ContainsEdge(SReversedEdge<TVertex, TEdge> edge)
        {
            return this.OriginalGraph.ContainsEdge(edge.OriginalEdge);
        }

        public int Degree(TVertex v)
        {
            return this.OriginalGraph.Degree(v);
        }

        public bool IsEdgesEmpty
        {
            get { return this.OriginalGraph.IsEdgesEmpty; }
        }

        public int EdgeCount
        {
            get { return this.OriginalGraph.EdgeCount; }
        }
    }
}
