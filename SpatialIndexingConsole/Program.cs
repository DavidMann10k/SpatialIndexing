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

            for (int i = 0; i < 100; i++)
            {
                octree.AddValue(Vector.Random(), "beer");
            }

            octree.PrintTree();

            Console.ReadKey();
        }
    }
}
