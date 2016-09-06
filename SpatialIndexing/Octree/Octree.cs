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
        private List<VectorValue<T>> values = new List<VectorValue<T>>(100);
        private DepthFirstPrintTreeOperation<T> printOp = new DepthFirstPrintTreeOperation<T>();
        private AddValueOperation<T> AddOp = new AddValueOperation<T>();
        
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
            root.ExecuteOperation(op, this.values);
        }

        public void PrintTree()
        {
            root.ExecuteOperation(printOp, values);
        }

        public List<T> GetValues(CubeBounds bounds)
        {
            return null;
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