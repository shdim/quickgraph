using System;
using System.Collections.Generic;

namespace QuickGraph.Predicates
{
    public sealed class ResidualEdgePredicate<TVertex,TEdge>
        where TEdge : IEdge<TVertex>
    {
		private readonly IDictionary<TEdge,double> residualCapacities;

        public ResidualEdgePredicate(
            IDictionary<TEdge,double> residualCapacities)
		{
            this.residualCapacities = residualCapacities;
		}

		public IDictionary<TEdge,double> ResidualCapacities
		{
			get
			{
				return this.residualCapacities;
			}
		}

		public bool Test(TEdge e)
		{
			return 0 < this.residualCapacities[e];
		}
    }
}
