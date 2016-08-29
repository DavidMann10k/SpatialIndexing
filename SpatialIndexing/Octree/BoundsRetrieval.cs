using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpatialIndexing.Octree
{
    class BoundsRetrieval<T> : IRetrieval<T>
    {
        public CubeBounds bounds { get; private set; }

        public BoundsRetrieval(CubeBounds bounds)
        {
            this.bounds = bounds;
        }

        public List<T> Execute(OctreeNode<T> node)
        {
            var values = new List<T>();

            if (node.Bounds.Intersects(this.bounds))
            {
                
            }

            return values;
        }
    }
}
