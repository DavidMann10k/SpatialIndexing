using System;

namespace SpatialIndexing
{
	public struct CubeBounds
	{
        // properties
		public Vector Origin { get { return origin; } }

		public float Size { get { return size; } }

        public Vector Extents { get { return extents; } }

        // constructors
        public CubeBounds(Vector origin, float size)
        {
            this.origin = origin;
            this.size = size;

            this.maxX = origin.x + (size / 2);
            this.maxY = origin.y + (size / 2);
            this.maxZ = origin.z + (size / 2);
            this.minX = origin.x - (size / 2);
            this.minY = origin.y - (size / 2);
            this.minZ = origin.z - (size / 2);

            this.extents = Vector.One * size * .5f;
        }

        // methods
        public bool Contains (Vector point)
		{
            return (point.x > minX &&
                    point.x <= maxX &&
                    point.y > minY &&
                    point.y <= maxY &&
                    point.z > minZ &&
                    point.z <= maxZ);
		}

        public bool Intersects(CubeBounds bounds)
        {
            return (Math.Abs(this.origin.x - bounds.origin.x) * 2 <= (this.size + bounds.size)) &&
                   (Math.Abs(this.origin.y - bounds.origin.y) * 2 <= (this.size + bounds.size)) &&
                   (Math.Abs(this.origin.z - bounds.origin.z) * 2 <= (this.size + bounds.size));
        }

        private Vector origin;

		private float size;

		private Vector extents;

		private float maxX;

		private float maxY;

		private float maxZ;

		private float minX;

		private float minY;

		private float minZ;

        public override string ToString()
        {
            return string.Format("{0} ({1}, {2})", base.ToString(), origin, size);
        }
    }
}