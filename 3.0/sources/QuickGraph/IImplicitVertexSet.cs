using System;

namespace QuickGraph
{
    /// <summary>
    /// An implicit set of vertices
    /// </summary>
    /// <typeparam name="TVertex">type of the vertices</typeparam>
    public interface IImplicitVertexSet<TVertex>
    {
        /// <summary>
        /// Determines whether the specified vertex contains vertex.
        /// </summary>
        /// <param name="vertex">The vertex.</param>
        /// <returns>
        /// 	<c>true</c> if the specified vertex contains vertex; otherwise, <c>false</c>.
        /// </returns>
        bool ContainsVertex(TVertex vertex);
    }
}
