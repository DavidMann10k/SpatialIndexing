namespace SpatialIndexing
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

    internal abstract class TreeNode<T>
    {
        public TreeNode(TreeNode<T> parent = null)
        {
            this.Parent = parent;
        }

        public TreeNode<T> Parent { get; private set; }

        public List<T> Values { get { return values; } }

        public bool IsLeaf { get { return this.children.Count == 0; } }

        public bool IsRoot { get { return this.Parent == null; } }

        public TreeNode<T> Root
        {
            get
            {
                if (this.IsRoot)
                {
                    return this;
                }
                else
                {
                    return this.Parent.Root;
                }
            }
        }

        public List<TreeNode<T>> Children { get { return children; } }

        protected List<TreeNode<T>> children = new List<TreeNode<T>>();

        protected List<T> values = new List<T>();        
    }
}
