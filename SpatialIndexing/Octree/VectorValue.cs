using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpatialIndexing.Octree
{
    public struct VectorValue<T>
    {
        public Vector Vector { get; set; }
        public T Value { get; set; }

        public VectorValue(Vector vector, T value)
        {
            this.Vector = vector;
            this.Value = value;
        }
    }
}
