using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpatialIndexing.Octree
{
    internal interface Operation<T>
    {
        void Execute(OctreeNode<T> node);
    }
}
