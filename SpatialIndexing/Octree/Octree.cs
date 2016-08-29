using System;
using System.Collections.Generic;

namespace SpatialIndexing.Octree
{
    public class Octree<T>
    {
        // properties
        public CubeBounds Bounds { get; private set; }
        public int MaxValuesPerNode { get; private set; }

        // fields
        private OctreeNode<T> root;
        
        // constructors
        public Octree(CubeBounds bounds)
        {
            this.Bounds = bounds;
            this.root = new OctreeNode<T>(bounds, 0);
            this.MaxValuesPerNode = 8;
        }

        // methods
        public bool Contains (Vector point)
        {
            return this.Bounds.Contains (point);
        }

        public void AddValue(Vector position, T value)
        {
            AddValueOperation<T> op = new AddValueOperation<T>(this, position, value);
            root.ExecuteOperation(op);
        }

        public void PrintTree()
        {
            root.ExecuteOperation(new DepthFirstPrintTreeOperation<T>());
        }

        public List<T> GetValues(CubeBounds bounds)
        {
            var retrieval = new BoundsRetrieval<T>(bounds);
            return root.ExecuteRetrieval(retrieval);
        }

        public int CountValues()
        {
            return root.DescendantValueCount();
        }

        public int CountNodes()
        {
            return root.DescendantCount();
        }

        public bool Intersects(CubeBounds bounds)
        {
            return this.Bounds.Intersects(bounds);
        }

        public object Contains(T value)
        {
            return root.Contains(value);
        }
    }
}