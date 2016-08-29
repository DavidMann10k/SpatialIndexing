using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpatialIndexing;
using SpatialIndexing.Octree;

namespace SpatialIndexingTest
{
    [TestClass]
    public class OctreeTests
    {
        [TestMethod]
        public void NewOctree()
        {
            var bounds = new CubeBounds(new Vector(0, 0, 0), 2);
            var octree = new Octree<string>(bounds);
            
            Assert.AreEqual<Vector>(new Vector(0, 0, 0), octree.Bounds.Origin);
            Assert.AreEqual<float>(2, octree.Bounds.Size);
            Assert.IsTrue(octree.Contains(Vector.Zero));
        }

        [TestMethod]
        public void ContainsPoints()
        {
            var bounds = new CubeBounds(new Vector(0, 0, 0), 2);
            var octree = new Octree<string>(bounds);

            // positive sides have inclusive borders
            Assert.IsTrue(octree.Contains(new Vector(0, 0, 0)));
            Assert.IsTrue(octree.Contains(new Vector(0, 0, 1)));
            Assert.IsTrue(octree.Contains(new Vector(0, 1, 0)));
            Assert.IsTrue(octree.Contains(new Vector(0, 1, 1)));
            Assert.IsTrue(octree.Contains(new Vector(1, 0, 0)));
            Assert.IsTrue(octree.Contains(new Vector(1, 0, 1)));
            Assert.IsTrue(octree.Contains(new Vector(1, 1, 0)));
            Assert.IsTrue(octree.Contains(new Vector(1, 1, 1)));

            // negative sides have exclusive borders
            Assert.IsFalse(octree.Contains(new Vector(-1, 0, 0)));
            Assert.IsFalse(octree.Contains(new Vector(-1, 0, 1)));
            Assert.IsFalse(octree.Contains(new Vector(-1, 1, 0)));
            Assert.IsFalse(octree.Contains(new Vector(-1, 1, 1)));
            Assert.IsFalse(octree.Contains(new Vector(0, 0, -1)));
            Assert.IsFalse(octree.Contains(new Vector(0, 1, -1)));
            Assert.IsFalse(octree.Contains(new Vector(0, -1, 0)));
            Assert.IsFalse(octree.Contains(new Vector(0, -1, 1)));
            Assert.IsFalse(octree.Contains(new Vector(0, -1, -1)));
            Assert.IsFalse(octree.Contains(new Vector(1, 0, -1)));
            Assert.IsFalse(octree.Contains(new Vector(1, 1, -1)));
            Assert.IsFalse(octree.Contains(new Vector(1, -1, 0)));
            Assert.IsFalse(octree.Contains(new Vector(1, -1, 1)));
            Assert.IsFalse(octree.Contains(new Vector(1, -1, -1)));
            Assert.IsFalse(octree.Contains(new Vector(-1, 0, -1)));
            Assert.IsFalse(octree.Contains(new Vector(-1, 1, -1)));
            Assert.IsFalse(octree.Contains(new Vector(-1, -1, 0)));
            Assert.IsFalse(octree.Contains(new Vector(-1, -1, 1)));
            Assert.IsFalse(octree.Contains(new Vector(-1, -1, -1)));
        }

        [TestMethod]
        public void NotContainsPoints()
        {
            var bounds = new CubeBounds(new Vector(0, 0, 0), 2);
            var octree = new Octree<string>(bounds);
            
            Assert.IsFalse(octree.Contains(new Vector(0, 0, 2)));
            Assert.IsFalse(octree.Contains(new Vector(0, 0, -2)));
            Assert.IsFalse(octree.Contains(new Vector(0, 2, 0)));
            Assert.IsFalse(octree.Contains(new Vector(0, 2, 2)));
            Assert.IsFalse(octree.Contains(new Vector(0, 2, -2)));
            Assert.IsFalse(octree.Contains(new Vector(0, -2, 0)));
            Assert.IsFalse(octree.Contains(new Vector(0, -2, 2)));
            Assert.IsFalse(octree.Contains(new Vector(0, -2, -2)));
            Assert.IsFalse(octree.Contains(new Vector(2, 0, 0)));
            Assert.IsFalse(octree.Contains(new Vector(2, 0, 2)));
            Assert.IsFalse(octree.Contains(new Vector(2, 0, -2)));
            Assert.IsFalse(octree.Contains(new Vector(2, 2, 0)));
            Assert.IsFalse(octree.Contains(new Vector(2, 2, 2)));
            Assert.IsFalse(octree.Contains(new Vector(2, 2, -2)));
            Assert.IsFalse(octree.Contains(new Vector(2, -2, 0)));
            Assert.IsFalse(octree.Contains(new Vector(2, -2, 2)));
            Assert.IsFalse(octree.Contains(new Vector(2, -2, -2)));
            Assert.IsFalse(octree.Contains(new Vector(-2, 0, 0)));
            Assert.IsFalse(octree.Contains(new Vector(-2, 0, 2)));
            Assert.IsFalse(octree.Contains(new Vector(-2, 0, -2)));
            Assert.IsFalse(octree.Contains(new Vector(-2, 2, 0)));
            Assert.IsFalse(octree.Contains(new Vector(-2, 2, 2)));
            Assert.IsFalse(octree.Contains(new Vector(-2, 2, -2)));
            Assert.IsFalse(octree.Contains(new Vector(-2, -2, 0)));
            Assert.IsFalse(octree.Contains(new Vector(-2, -2, 2)));
            Assert.IsFalse(octree.Contains(new Vector(-2, -2, -2)));
        }

        [TestMethod]
        public void ContainsValues()
        {
            var bounds = new CubeBounds(new Vector(0, 0, 0), 2);
            var octree = new Octree<string>(bounds);

            octree.AddValue(Vector.Zero, "fee");
            octree.AddValue(Vector.One, "fi");

            Assert.IsNotNull(octree.Contains("fee"));
            Assert.IsNotNull(octree.Contains("fi"));
        }

        [TestMethod]
        public void CountValues()
        {
            var bounds = new CubeBounds(new Vector(0, 0, 0), 2);
            var octree = new Octree<string>(bounds);

            for (int i = 0; i < 100; i++)
            {
                octree.AddValue(Vector.Random(), "beer");
            }

            Assert.AreEqual(100, octree.CountValues());
        }

        [TestMethod]
        public void Intersection()
        {
            var bounds = new CubeBounds(Vector.Zero, 2);
            var octree = new Octree<string>(bounds);

            Assert.IsTrue(bounds.Intersects(new CubeBounds(Vector.Zero, 2)));
            Assert.IsTrue(bounds.Intersects(new CubeBounds(Vector.One, 1)));
            Assert.IsTrue(bounds.Intersects(new CubeBounds(new Vector(2,2,2), 2)));
        }
    }
}
