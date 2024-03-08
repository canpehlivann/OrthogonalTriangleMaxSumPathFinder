using System;
using System.Collections.Generic;

namespace OrthogonalTriangleMaxSumPathFinder
{
    internal class LeftDiagonalStrategy : IVectorStrategy
    {
        public Vector2 GetNext(Vector2 vector, Dictionary<Coordinates, Vector2> lookupTable)
        {
            return vector.GetLeftDiagonal(lookupTable);
        }
    }
}
