using System;
using SpatialIndexing;
using SpatialIndexing.Octree;

namespace SpatialIndexingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var bounds = new CubeBounds(Vector.Zero, 2);
            var octree = new Octree<string>(bounds);

            //for (int i = 0; i < 100; i++)
            //{
            //    octree.AddValue(Vector.Random(), "beer");
            //}

            //octree.PrintTree();

            var point = Vector.Zero;
            OctreeNode<string> node = new OctreeNode<string>(bounds, 0);
            node.Split();

            foreach (var child in node.Children)
            {
                Console.Write(child.Index + " ");
                Console.WriteLine(child.Bounds.Contains(point));
            }

            Console.WriteLine(node.GetChildContainingPoint(point).Index);

            Console.ReadKey();
        }
    }
}
