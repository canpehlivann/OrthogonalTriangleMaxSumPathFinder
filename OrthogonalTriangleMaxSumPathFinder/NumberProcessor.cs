using System;
using System.Collections.Generic;

namespace OrthogonalTriangleMaxSumPathFinder
{
    internal class NumberProcessor
    {
        public static bool IsPrime(Vector2 vector)
        {
            return OrthogonalTriangleProcessor.IsPrime(vector.magnitude);
        }
    }
}
