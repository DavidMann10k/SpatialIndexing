using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpatialIndexing.Octree
{
    internal class DepthFirstPrintTreeOperation<T> : Operation<T>
    {
        public void Execute(OctreeNode<T> node)
        {
            Console.WriteLine("Node" + node.id + " Values: " + node.Values.Count);
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
