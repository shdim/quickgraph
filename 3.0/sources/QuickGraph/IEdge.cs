namespace QuickGraph
{
    /// <summary>
    /// A directed edge
    /// </summary>
    /// <typeparam name="TVertex">type of the vertices</typeparam>
    public interface IEdge<TVertex>
    {
        /// <summary>
        /// Gets the source vertex
        /// </summary>
        TVertex Source { get;}
        /// <summary>
        /// Gets the target vertex
        /// </summary>
        TVertex Target { get;}
    }
}
