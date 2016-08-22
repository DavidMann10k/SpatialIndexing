using System;
using SpatialIndexing;
using SpatialIndexing.Octree;

namespace SpatialIndexingConsole
{
    class Program
    {
        public static Random rand = new Random();

        static void Main(string[] args)
        {
            var bounds = new CubeBounds(Vector.Zero, 2);
            var octree = new Octree<string>(bounds);

            //for (int i = 0; i < 100; i++)
            //{
            //    octree.AddValue(RandomVector(), "beer");
            //}

            octree.AddValue(Vector.One * 5, "beer");

            octree.PrintTree();
            

            Console.ReadKey();
        }

        static Vector RandomVector()
        {
            return new Vector((float)rand.NextDouble() * 2.0f, (float)rand.NextDouble() * 2.0f, (float)rand.NextDouble() * 2.0f);
        }
    }
}
