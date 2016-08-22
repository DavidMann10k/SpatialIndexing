namespace SpatialIndexing
{
	public struct Vector
	{
		public float x;

		public float y;

		public float z;

		public Vector (float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static Vector operator * (Vector vector, float factor)
		{
			return new Vector (vector.x * factor, vector.y * factor, vector.z * factor);
		}

		public static Vector One { get { return new Vector (1, 1, 1); } }

        public static Vector Zero { get { return new Vector (0, 0, 0); } }

        public override string ToString()
        {
            return string.Format("{0} ({1}, {2}, {3})", base.ToString(), x, y, z);
        }
    }
}