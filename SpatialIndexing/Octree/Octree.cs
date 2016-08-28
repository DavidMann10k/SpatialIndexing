namespace SpatialIndexing.Octree
{
    public class Octree<T>
    {
        public Octree(CubeBounds bounds, int height = 3)
        {
            this.Bounds = bounds;
            this.root = new OctreeNode<T>(bounds, 0);
            this.Height = height;
        }

		public CubeBounds Bounds { get; private set; }

		public int Height { get; private set; }

        private OctreeNode<T> root;

        public bool Contains (Vector point)
		{
			return this.Bounds.Contains (point);
		}

        public void AddValue(Vector position, T value)
        {
            AddValueOperation<T> op = new AddValueOperation<T>(position, value, Height);
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