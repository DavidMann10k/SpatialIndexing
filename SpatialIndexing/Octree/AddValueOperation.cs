using System;
using System.Collections.Generic;

namespace SpatialIndexing.Octree
{
    internal class AddValueOperation<T> : IOperation<T>
    {

        public AddValueOperation(Octree<T> octree)
        {
            this.octree = octree;
        }

        private Octree<T> octree;

        public void Execute(OctreeNode<T> node, List<VectorValue<T>> values)
        {
            if (node.IsLeaf)
            {
                // add values to this node
                // split if values.count > octree.maxValuesPerNode
            
            }
            else
            {
                // execute AddValueOperation on each child with values
            }
        }
    }
}
