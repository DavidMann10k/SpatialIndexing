namespace SpatialIndexing.Octree
{
    internal interface iOperation<T>
    {
        void Execute(OctreeNode<T> node);
    }
}
