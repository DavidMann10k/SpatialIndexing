using System;

namespace SpatialIndexing.Octree
{
    internal class AddValueOperation<T> : iOperation<T>
    {

        public AddValueOperation(Octree<T> octree,  Vector position, T value)
        {
            this.Position = position;
            this.Value = value;
            this.octree = octree;
        }

        private Octree<T> octree;
        private Vector Position;
        private T Value;

        public void Execute(OctreeNode<T> node)
        {
            if (!node.Contains(Position))
                throw new Exception("Point outside of octree node bounds.");

            if (node.Values.Count >= octree.MaxValuesPerNode)
            {
                if (node.IsLeaf)
                {
                    node.Split();
                }

                var octant = node.GetChildContainingPoint(Position);
                octant.PerformOperation(this);
            }
            else
            {
                node.Values.Add(Value);
            }
        }
    }
}
