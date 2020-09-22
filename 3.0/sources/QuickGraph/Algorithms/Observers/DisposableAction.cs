using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickGraph.Algorithms.Observers
{
    struct DisposableAction
        : IDisposable
    {
        public delegate void Action();

        Action action;

        public DisposableAction(Action action)
        {
            this.action = action;
        }

        public void Dispose()
        {
            var a = this.action;
            this.action = null;
            if (a != null)
                a();
        }
    }
}
