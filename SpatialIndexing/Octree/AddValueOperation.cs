using System;

namespace SpatialIndexing.Octree
{
    internal class AddValueOperation<T> : iOperation<T>
    {

        public AddValueOperation(Octree<T> octree,  Vector position, T value)
        {
            this.position = position;
            this.Value = value;
            this.octree = octree;
        }

        private Octree<T> octree;
        private Vector position;
        private T Value;

        public void Execute(OctreeNode<T> node)
        {
            if (!node.Contains(position))
                throw new Exception("Point outside of octree node bounds.");

            if (node.Values.Count >= octree.MaxValuesPerNode)
            {
                if (node.IsLeaf)
                {
                    node.Split();
                    foreach(var value in node.Values)
                    {

                    }
                }

                var octant = node.GetChildContainingPoint(position);
                octant.PerformOperation(this);
            }
            else
            {
                node.Values.Add(position, Value);
            }
        }
    }
}
