namespace SpatialIndexing.Octree
{
    using System;

    /// <summary>
    /// Node used in an octree.
    /// </summary>
    internal class OctreeNode<T> : TreeNode<T>
    {
        public OctreeNode(CubeBounds bounds, int index, OctreeNode<T> parent = null)
            : base()
        {
            this.Bounds = bounds;
            this.index = index;
        }

        public OctreeNode<T> this[int i]
        {
            get { return (OctreeNode<T>)children[i]; }
        }

        public int Index { get { return index; } }

        public CubeBounds Bounds { get; private set; }

        public float OctantSize { get { return this.Bounds.Size / 2; } }

        public bool Contains (Vector point)
		{
			return this.Bounds.Contains (point);
        }

        private int index;

        public void Split ()
		{
            for (int i = 0; i < 8; i++)
            {
                children.Add(new OctreeNode<T>(new CubeBounds(GetOctantOrigin(i), this.OctantSize), GetChildIndex(i), this));
            }
        }

        private int GetChildIndex(int index)
        {
            var new_index = this.index << 3;
            new_index |= index;
            return new_index;
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

        internal int CountNodes()
        {
            var count = 0;
            foreach (OctreeNode<T> child in children)
            {
                count += child.CountNodes();
            }
            return ++count;
        }

        public int CountValues()
        {
            var count = 0;
            foreach (OctreeNode<T> child in children)
            {
                count += child.CountValues();
            }
            count += values.Count;
            return count;
        }

        public OctreeNode<T> GetSmallestOctantContainingPoint(Vector point)
        {
            if (this.IsLeaf)
            {
                return this;
            }
            else
            {
                int index = 0;
                if (point.x >= this.Bounds.Origin.x)
                {
                    index |= 4;
                }

                if (point.y >= this.Bounds.Origin.y)
                {
                    index |= 2;
                }

                if (point.z >= this.Bounds.Origin.z)
                {
                    index |= 1;
                }

                if (children[index].IsLeaf)
                {
                    return (OctreeNode<T>)this.children[index];
                }
                else
                {
                    return ((OctreeNode<T>)this.children[index]).GetSmallestOctantContainingPoint(point);
                }
            }
        }

        public OctreeNode<T> GetChildContainingPoint(Vector point)
        {
            if (!this.Contains(point))
                return null;

            if (this.IsLeaf)
            {
                Split();
                return GetChildContainingPoint(point);
            }
            else
            {
                return (OctreeNode<T>)this.children[GetOctantIndex(point)];
            }
        }

        private int GetOctantIndex(Vector point)
        {
            int index = 0;
            if (point.x >= this.Bounds.Origin.x)
            {
                index |= 4;
            }

            if (point.y >= this.Bounds.Origin.y)
            {
                index |= 2;
            }

            if (point.z >= this.Bounds.Origin.z)
            {
                index |= 1;
            }

            return index;
        }

        public void PerformOperation(iOperation<T> op)
        {
            op.Execute(this);
        }

        public Vector GetOctantOrigin (int index)
		{
			var origin = this.Bounds.Origin;
			origin.x += Bounds.Extents.x * (Convert.ToBoolean (index & 4) ? .5f : -.5f);
			origin.y += Bounds.Extents.y * (Convert.ToBoolean (index & 2) ? .5f : -.5f);
			origin.z += Bounds.Extents.z * (Convert.ToBoolean (index & 1) ? .5f : -.5f);
			return origin;
		}
	}
}
