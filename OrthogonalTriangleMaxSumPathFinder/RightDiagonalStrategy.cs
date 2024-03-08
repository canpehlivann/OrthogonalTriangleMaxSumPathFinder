using System;
using System.Collections.Generic;

namespace OrthogonalTrianglePathMaxSum
{
    internal class RightDiagonalStrategy : IVectorStrategy
    {
        public Vector2 GetNext(Vector2 vector, Dictionary<Coordinates, Vector2> lookupTable)
        {
            return vector.GetRightDiagonal(lookupTable);
        }
    }
}
