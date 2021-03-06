using System.Diagnostics.Contracts;
using Mono.GameMath;

namespace Trinity.Encore.Game.Partitioning
{
    /// <summary>
    /// Represents a quad tree data structure.
    /// </summary>
    public sealed class QuadTree : QuadTreeNode
    {
        /// <summary>
        /// The default depth threshold for partitioning.
        /// </summary>
        public const int DefaultDepthThreshold = 6;

        public const int NoMaxCount = -1;

        public QuadTree(BoundingBox bounds, int depthThreshold = DefaultDepthThreshold)
            : base(bounds)
        {
            Contract.Requires(depthThreshold > 0);

            Partition(depthThreshold, 0);
        }
    }
}
