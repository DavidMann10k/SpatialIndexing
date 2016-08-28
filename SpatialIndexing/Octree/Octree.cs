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
            root.PerformOperation(op);
        }

        public void PrintTree()
        {
            root.PerformOperation(new DepthFirstPrintTreeOperation<T>());
        }

        public int CountValues()
        {
            return root.CountValues();
        }

        public int CountNodes()
        {
            return root.CountNodes();
        }
    }
}