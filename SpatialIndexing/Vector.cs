using System;
using System.Collections.Generic;

namespace SpatialIndexing
{
    public struct Vector
    {
        public static Random rand = new Random();

        public static List<Vector> directions { get { return new List<Vector>() { left, right, up, down, forward, backward }; } }

        public static Vector left { get { return new Vector(-1, 0, 0); } }
        public static Vector right { get { return new Vector(1, 0, 0); } }
        public static Vector up { get { return new Vector(0, 1, 0); } }
        public static Vector down { get { return new Vector(0, -1, 0); } }
        public static Vector forward { get { return new Vector(0, 0, 1); } }
        public static Vector backward { get { return new Vector(0, 0, -1); } }

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
        
        public static Vector Random()
        {
            return new Vector((float)rand.NextDouble() * 2 - 1, (float)rand.NextDouble() * 2 - 1, (float)rand.NextDouble() * 2 - 1);
        }
    }
}