using System.Collections.Generic;

namespace SpatialIndexing.Octree
{
    // TODO: make internal
    public interface IRetrieval<T>
    {
        List<T> Execute(OctreeNode<T> node);
    }
}
