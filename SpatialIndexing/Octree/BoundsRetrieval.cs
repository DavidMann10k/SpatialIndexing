using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpatialIndexing.Octree
{
    class GetValuesInBounds<T> : IOperation<T>
    {
        public CubeBounds bounds { get; private set; }

        public GetValuesInBounds(CubeBounds bounds)
        {
            this.bounds = bounds;
        }

        public void Execute(OctreeNode<T> node, List<VectorValue<T>> values)
        {
            if (node.Bounds.Intersects(this.bounds))
            {
                
            }
        }
    }
}
