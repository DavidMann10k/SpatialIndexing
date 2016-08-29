using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpatialIndexing.Octree
{
    class FindValueNearestPointOperation<T> : IOperation<T>
    {
        FindValueNearestPointOperation(Vector point)
        {
            this.point = point;
        }

        Vector point;

        public void Execute(OctreeNode<T> node)
        {
            var containing_node = node.GetLeafContaininPoint(point);
            var values = containing_node.Values;

            var size = containing_node.Size;

            foreach(var direction in Vector.directions)
            {
                var point = direction * node.Size;
                //node.GetSmallestOctantContainingPoint()
            }
        }
    }
}
