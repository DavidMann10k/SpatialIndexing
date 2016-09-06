using System.Collections.Generic;

namespace SpatialIndexing.Octree
{
    class FindValueNearestPointOperation<T> : IOperation<T>
    {
        FindValueNearestPointOperation(Vector point)
        {
            this.point = point;
        }

        Vector point;

        public void Execute(OctreeNode<T> node, List<VectorValue<T>> values)
        {
            values.Clear();

            var containing_node = node.GetLeafContaininPoint(point);
            values = containing_node.Values;

            var size = containing_node.Size;

            foreach(var direction in Vector.directions)
            {
                var point = direction * node.Size;
                //node.GetSmallestOctantContainingPoint()
            }
        }
    }
}
