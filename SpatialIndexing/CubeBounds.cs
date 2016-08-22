namespace SpatialIndexing
{
	public struct CubeBounds
	{
		public CubeBounds (Vector origin, float size)
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

		public Vector Origin { get { return origin; } }

		public float Size { get { return size; } }

        public Vector Extents { get { return extents; } }

        public bool Contains (Vector point)
		{
			if (point.x < minX)
				return false;
			if (point.y < minY)
				return false;
			if (point.z < minZ)
				return false;

			if (point.x > maxX)
				return false;
			if (point.y > maxY)
				return false;
			if (point.z > maxZ)
				return false;

			return true;
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