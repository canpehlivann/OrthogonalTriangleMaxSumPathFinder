//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Runtime.Intrinsics;
//using System.Text;
//using System.Threading.Tasks;

//namespace OrthogonalTrianglePathMaxSum
//{
//    internal class VectorProcessor
//    {
//        private readonly IVectorStrategy downStrategy;
        
//        private readonly IVectorStrategy rightDiagonalStrategy;

//        private readonly IVectorStrategy leftDiagonalStrategy;

//        public VectorProcessor(IVectorStrategy downStrategy, IVectorStrategy rightDiagonalStrategy, IVectorStrategy leftDiagonalStrategy)
//        {
//            this.downStrategy = downStrategy;
//            this.rightDiagonalStrategy = rightDiagonalStrategy;
//            this.leftDiagonalStrategy = leftDiagonalStrategy;
//        }

//        public void ProcessVector(Vector2 vec, Dictionary<Coordinates, Vector2> lookupTable, ref int sum)
//        {

//            var isDownPrime = NumberProcessor.IsPrime(downStrategy.GetNext(vec, lookupTable));

//            var isRightPrime = NumberProcessor.IsPrime(rightDiagonalStrategy.GetNext(vec, lookupTable));

//            var isLeftPrime = NumberProcessor.IsPrime(leftDiagonalStrategy.GetNext(vec, lookupTable));

//            if (vec.x == 0) //Meaning this vector can only have two adjacents. Down and Right.
//            {
//                vec = (isDownPrime == false) ? downStrategy.GetNext(vec, lookupTable) : (isDownPrime == true) ? rightDiagonalStrategy.GetNext(vec, lookupTable) : ProcessNonPrimes(vec, downStrategy.GetNext(vec, lookupTable), rightDiagonalStrategy.GetNext(vec, lookupTable), isRightPrime, isDownPrime);
//            }
            
//            else if(vec.x > 0)
//            {
//                vec = (isDownPrime == false) ? ProcessAdjacent(downStrategy.GetNext(vec, lookupTable), rightDiagonalStrategy.GetNext(vec, lookupTable), isRightPrime, isLeftPrime);
//            }

//            sum += vec.magnitude;

//            Console.WriteLine($"\nAdded number to the sum: {vector.magnitude}");

//            Console.WriteLine($"Sum: {sum}");

//        }
//    }
//}
