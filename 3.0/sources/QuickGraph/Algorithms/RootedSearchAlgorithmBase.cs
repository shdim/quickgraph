using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGraph.Algorithms.Services;

namespace QuickGraph.Algorithms
{
    public abstract class RootedSearchAlgorithmBase<TVertex, TGraph>
        : RootedAlgorithmBase<TVertex, TGraph>
    {
        private TVertex _goalVertex;
        private bool hasGoalVertex;

        protected RootedSearchAlgorithmBase(
            IAlgorithmComponent host,
            TGraph visitedGraph)
            :base(host, visitedGraph)
        {}

        public bool TryGetGoalVertex(out TVertex goalVertex)
        {
            if (this.hasGoalVertex)
            {
                goalVertex = this._goalVertex;
                return true;
            }
            else
            {
                goalVertex = default(TVertex);
                return false;
            }
        }

        public void SetGoalVertex(TVertex goalVertex)
        {
            bool changed = Comparer<TVertex>.Default.Compare(this._goalVertex, goalVertex) != 0;
            this._goalVertex = goalVertex;
            if (changed)
                this.OnGoalVertexChanged(EventArgs.Empty);
            this.hasGoalVertex = true;
        }

        public void ClearGoalVertex()
        {
            this._goalVertex = default(TVertex);
            this.hasGoalVertex = false;
        }

        public event EventHandler GoalReached;
        protected virtual void OnGoalReached()
        {
            var eh = this.GoalReached;
            if (eh != null)
                eh(this, EventArgs.Empty);
        }

        public event EventHandler GoalVertexChanged;
        protected virtual void OnGoalVertexChanged(EventArgs e)
        {
            var eh = this.GoalVertexChanged;
            if (eh != null)
                eh(this, e);
        }

        public void Compute(TVertex root, TVertex goal)
        {
            this.SetGoalVertex(goal);
            this.Compute(root);
        }
    }
}
