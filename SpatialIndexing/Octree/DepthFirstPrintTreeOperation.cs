using System;

namespace SpatialIndexing.Octree
{
    internal class DepthFirstPrintTreeOperation<T> : iOperation<T>
    {
        public void Execute(OctreeNode<T> node)
        {
            Console.WriteLine("Node" + Convert.ToString(node.Index, 2) + " Nodes: " + node.CountNodes());
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
