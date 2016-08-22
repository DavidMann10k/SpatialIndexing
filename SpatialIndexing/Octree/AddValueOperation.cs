using System;

namespace SpatialIndexing.Octree
{
    internal struct AddValueOperation<T> : Operation<T>
    {
        public AddValueOperation(Vector position, T value, int height)
        {
            this.Position = position;
            this.Value = value;
            this.Height = height;
            Level = 0;
        }

        public Vector Position;
        public T Value;
        public int Height;
        public int Level;

        public void Execute(OctreeNode<T> node)
        {
            if (!node.Contains(Position))
                throw new Exception("Point outside of octree node bounds.");

            if (Level < Height)
            {
                Level++;

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
