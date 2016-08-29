namespace SpatialIndexing.Octree
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Node used in an octree.
    /// </summary>
    /// TODO: Make internal
    public class OctreeNode<T>
    {
        // indexers
        public OctreeNode<T> this[int i] { get { return (OctreeNode<T>)children[i]; } }

        // properties
        public int Index { get; private set; }

        public CubeBounds Bounds { get; private set; }

        public float Size { get { return this.Bounds.Size; } }

        public float OctantSize { get { return this.Bounds.Size / 2; } }

        public List<VectorValue<T>> Values { get { return this.values; } }

        public bool IsRoot { get { return this.parent == null; } }

        public bool IsLeaf { get { return children.Count <= 0; } }

        public List<OctreeNode<T>> Children { get { return children; } }

        // fields
        private List<VectorValue<T>> values = new List<VectorValue<T>>();

        private List<OctreeNode<T>> children = new List<OctreeNode<T>>();

        private OctreeNode<T> parent;

        // constructors
        public OctreeNode(CubeBounds bounds, int index, OctreeNode<T> parent = null)
        {
            this.Bounds = bounds;
            this.Index = index;
            this.parent = parent;
        }

        // methods
        public bool Contains(T value)
        {
            foreach (var child in children)
            {
                if (child.Contains(value))
                {
                    return true;
                }
            }
            return Values.Any(i => i.Value.Equals(value));
        }

        public void Split ()
		{
            for (int i = 0; i < 8; i++)
            {
                children.Add(new OctreeNode<T>(new CubeBounds(GetOctantOrigin(i), this.OctantSize), GetChildIndex(i), this));
            }

            foreach(var value in values)
            {
                GetChildContainingPoint(value.Vector).Values.Add(value);
            }

            values.Clear();
        }

        public void Collapse()
        {
            foreach(OctreeNode<T> child in children)
            {
                child.Collapse();
                values.AddRange(child.values);
                children.Clear();
            }
        }

        public int DescendantCount()
        {
            var count = 0;
            foreach (OctreeNode<T> child in children)
            {
                count += child.DescendantCount();
            }
            return ++count;
        }

        public int DescendantValueCount()
        {
            var count = 0;
            foreach (OctreeNode<T> child in children)
            {
                count += child.DescendantValueCount();
            }
            count += values.Count;
            return count;
        }

        public OctreeNode<T> GetChildContainingPoint(Vector point)
        {
            if (!this.Bounds.Contains(point))
                return null;
            
            return (OctreeNode<T>)this.children[GetOctantIndexContainingPoint(point)];
        }

        public void ExecuteOperation(IOperation<T> op)
        {
            op.Execute(this);
        }

        public List<T> ExecuteRetrieval(IRetrieval<T> op)
        {
            return op.Execute(this);
        }

        public OctreeNode<T> GetLeafContaininPoint(Vector point)
        {
            if (this.IsLeaf)
            {
                return this;
            }
            else
            {
                var i = GetOctantIndexContainingPoint(point);

                if (children[i].IsLeaf)
                {
                    return (OctreeNode<T>)this.children[i];
                }
                else
                {
                    return ((OctreeNode<T>)this.children[i]).GetLeafContaininPoint(point);
                }
            }
        }

        // private methods
        private Vector GetOctantOrigin (int index)
		{
			var origin = this.Bounds.Origin;
			origin.x += Bounds.Extents.x * (Convert.ToBoolean (index & 4) ? .5f : -.5f);
			origin.y += Bounds.Extents.y * (Convert.ToBoolean (index & 2) ? .5f : -.5f);
			origin.z += Bounds.Extents.z * (Convert.ToBoolean (index & 1) ? .5f : -.5f);
			return origin;
        }

        private int GetOctantIndexContainingPoint(Vector point)
        {
            int index = 0;
            if (point.x >= this.Bounds.Origin.x)
                index |= 4;

            if (point.y >= this.Bounds.Origin.y)
                index |= 2;

            if (point.z >= this.Bounds.Origin.z)
                index |= 1;

            return index;
        }

        private int GetChildIndex(int index)
        {
            var new_index = this.Index << 3;
            new_index |= index;
            return new_index;
        }
    }
}
