using System;
using System.Collections.Generic;

namespace SpatialIndexing.Octree
{
    internal class DepthFirstPrintTreeOperation<T> : IOperation<T>
    {
        public void Execute(OctreeNode<T> node, List<VectorValue<T>> values)
        {
            if (node.IsRoot)
                Console.Write("Root Node, ");
            else
                Console.Write(String.Format("#{0}, ", node.Index));

            Console.WriteLine(String.Format("descendants: {0}, decendent values: {1}", node.DescendantCount(), node.DescendantValueCount()));

            foreach(OctreeNode<T> child in node.Children)
            {
                child.ExecuteOperation(this, values);
            }
        }
    }
}
