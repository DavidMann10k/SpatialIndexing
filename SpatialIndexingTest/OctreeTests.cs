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
            
            Assert.AreEqual<int>(3, octree.Height);
            Assert.AreEqual<Vector>(new Vector(0, 0, 0), octree.Bounds.Origin);
            Assert.AreEqual<float>(2, octree.Bounds.Size);
            Assert.IsTrue(octree.Contains(Vector.Zero));
        }

        [TestMethod]
        public void ContainsPoints()
        {
            var bounds = new CubeBounds(new Vector(0, 0, 0), 2);
            var octree = new Octree<string>(bounds);
            
            Assert.IsTrue(octree.Contains(new Vector(0, 0, 0)));
            Assert.IsTrue(octree.Contains(new Vector(0, 0, 1)));
            Assert.IsTrue(octree.Contains(new Vector(0, 0, -1)));
            Assert.IsTrue(octree.Contains(new Vector(0, 1, 0)));
            Assert.IsTrue(octree.Contains(new Vector(0, 1, 1)));
            Assert.IsTrue(octree.Contains(new Vector(0, 1, -1)));
            Assert.IsTrue(octree.Contains(new Vector(0, -1, 0)));
            Assert.IsTrue(octree.Contains(new Vector(0, -1, 1)));
            Assert.IsTrue(octree.Contains(new Vector(0, -1, -1)));
            Assert.IsTrue(octree.Contains(new Vector(1, 0, 0)));
            Assert.IsTrue(octree.Contains(new Vector(1, 0, 1)));
            Assert.IsTrue(octree.Contains(new Vector(1, 0, -1)));
            Assert.IsTrue(octree.Contains(new Vector(1, 1, 0)));
            Assert.IsTrue(octree.Contains(new Vector(1, 1, 1)));
            Assert.IsTrue(octree.Contains(new Vector(1, 1, -1)));
            Assert.IsTrue(octree.Contains(new Vector(1, -1, 0)));
            Assert.IsTrue(octree.Contains(new Vector(1, -1, 1)));
            Assert.IsTrue(octree.Contains(new Vector(1, -1, -1)));
            Assert.IsTrue(octree.Contains(new Vector(-1, 0, 0)));
            Assert.IsTrue(octree.Contains(new Vector(-1, 0, 1)));
            Assert.IsTrue(octree.Contains(new Vector(-1, 0, -1)));
            Assert.IsTrue(octree.Contains(new Vector(-1, 1, 0)));
            Assert.IsTrue(octree.Contains(new Vector(-1, 1, 1)));
            Assert.IsTrue(octree.Contains(new Vector(-1, 1, -1)));
            Assert.IsTrue(octree.Contains(new Vector(-1, -1, 0)));
            Assert.IsTrue(octree.Contains(new Vector(-1, -1, 1)));
            Assert.IsTrue(octree.Contains(new Vector(-1, -1, -1)));
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
        public void AddValues()
        {
            var bounds = new CubeBounds(new Vector(0, 0, 0), 2);
            var octree = new Octree<string>(bounds);

            octree.AddValue(Vector.Zero, "fee");
            octree.AddValue(Vector.One, "fi");
            octree.AddValue(Vector.One * -1, "fo");
            octree.AddValue(Vector.One, "fum");
        }
    }
}
