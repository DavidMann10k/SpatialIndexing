using System.Collections.Generic;

namespace SpatialIndexing.Octree
{
    // TODO: make internal
    public interface IOperation<T>
    {
        void Execute(OctreeNode<T> node, List<VectorValue<T>> values);
    }
}
