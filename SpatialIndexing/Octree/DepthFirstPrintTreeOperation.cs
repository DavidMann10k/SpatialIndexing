using System;

namespace SpatialIndexing.Octree
{
    internal class DepthFirstPrintTreeOperation<T> : iOperation<T>
    {
        public void Execute(OctreeNode<T> node)
        {
            Console.WriteLine(String.Format("Node #{0} Nodes: {1} Values: {2}", node.Index, node.CountNodes(), node.CountValues()));
            //foreach (T value in node.Values)
            //{
            //    Console.WriteLine(value.ToString());
            //}
            foreach(OctreeNode<T> child in node.Children)
            {
                child.PerformOperation(this);
            }
        }
    }
}
