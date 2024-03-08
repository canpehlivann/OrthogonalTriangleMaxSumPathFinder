using System; 
using System.Collections.Generic;

namespace OrthogonalTriangleMaxSumPathFinder
{
    internal interface IVectorStrategy
    {
        // Determines the next vector based on the current strategy.
        Vector2 GetNext(Vector2 currentVector, Dictionary<Coordinates, Vector2> lookupTable);
      
    }
}
