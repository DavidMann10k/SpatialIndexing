using System;

namespace SpatialIndexing.Octree
{
    internal class AddValueOperation<T> : iOperation<T>
    {
        public AddValueOperation(Vector position, T value, int minimum_height)
        {
            this.Position = position;
            this.Value = value;
            this.Height = minimum_height;
            Level = 0;
        }

        public AddValueOperation(Vector position, T value)
        {
            this.Position = position;
            this.Value = value;
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
