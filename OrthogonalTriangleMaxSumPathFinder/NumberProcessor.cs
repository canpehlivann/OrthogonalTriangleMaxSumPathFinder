using System;
using System.Collections.Generic;

namespace OrthogonalTrianglePathMaxSum
{
    internal class NumberProcessor
    {
        public static bool IsPrime(Vector2 vector)
        {
            return OrthogonalTriangleProcessor.IsPrime(vector.magnitude);
        }
    }
}
