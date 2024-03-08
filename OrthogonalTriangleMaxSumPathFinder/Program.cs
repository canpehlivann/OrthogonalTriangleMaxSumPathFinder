namespace OrthogonalTriangleMaxSumPathFinder
{
    class Program
    { 
        static void Main()
        {
            string? filePath;

            Console.WriteLine("##### Welcome to the orthogonal pyramid path sum calculator. #####\n");
            Console.WriteLine("This program calculates the maximum sum of the path of a given orthogonal pyramid as a text file.\n");

            do
            {
                Console.WriteLine("Please specify the file path of the pyramid to start.\n");
                Console.Write("Path: \n");

                filePath = Console.ReadLine();

                try
                {
                    if (File.Exists(filePath) == false)
                    {
                        Console.WriteLine("The file path is entered wrong. Please specify the full path of the file.");

                        continue;
                    }

                }

                catch (Exception e)
                {
                    Console.WriteLine("An error is encountered:");
                    Console.WriteLine(e.Message);
                }

            } while (File.Exists(filePath) == false || filePath == null);
            
            List<int> triangle = OrthogonalTriangleProcessor.ReadOrthogonalTriangleFromFile(filePath);

            var lines = OrthogonalTriangleProcessor.CountLinesFromFile(filePath);

            List<Vector2> triangleElements = OrthogonalTriangleProcessor.ConvertToVector2(triangle);

            Dictionary<Coordinates,Vector2> lookupTable = OrthogonalTriangleProcessor.CreatelookupTable(triangleElements);

            Vector2 vector = triangleElements[0]; //Start vector of the path.

            var sum = vector.magnitude; // Sum of the non primes. Starts from 215.

            IVectorStrategy downVectorStrategy = new DownStrategy();

            IVectorStrategy rightDiagonalVectorStrategy = new RightDiagonalStrategy();

            IVectorStrategy leftDiagonalVectorStrategy = new LeftDiagonalStrategy();
            
            Console.WriteLine($"\nSum: {sum}");

            for (var i = 0; i < lines - 1; i++)
            {
                //TO DO: I did not like this part below. It has repetition.

                if (vector.x == 0) //Meaning the vector can have only 2 adjacents. x can't be -1 because of it's the left edge.
                {

                    var isPrime = NumberProcessor.IsPrime(downVectorStrategy.GetNext(vector, lookupTable));

                    var isOtherPrime = NumberProcessor.IsPrime(rightDiagonalVectorStrategy.GetNext(vector, lookupTable));

                    var comparison = isPrime.CompareTo(isOtherPrime);

                    if (comparison == 0) //If both of two numbers are a non-prime.
                    {
                        var downAdjacent = downVectorStrategy.GetNext(vector, lookupTable);

                        var rightAdjacent = rightDiagonalVectorStrategy.GetNext(vector, lookupTable);

                        var max = Math.Max(downAdjacent.magnitude, rightAdjacent.magnitude);

                        if (max == downAdjacent.magnitude)
                        {
                            vector = downAdjacent;
                        }

                        else
                        {
                            vector = rightAdjacent;
                        }
                    }

                    else if (comparison < 0) //Just the down adjacent is a non-prime.
                    {
                        var downAdjacent = downVectorStrategy.GetNext(vector, lookupTable);

                        vector = downAdjacent;
                    }

                    else //Just the right adjacent is a non-prime.
                    {

                        var rightAdjacent = rightDiagonalVectorStrategy.GetNext(vector, lookupTable);

                        vector = rightAdjacent;
                    }
                }

                else
                {
                    var isPrime = NumberProcessor.IsPrime(downVectorStrategy.GetNext(vector, lookupTable)); //Check if the down adjacent is a prime or not.

                    var isRightDiagonalPrime = NumberProcessor.IsPrime(rightDiagonalVectorStrategy.GetNext(vector, lookupTable)); //Check if the right-diag adjacent is a prime or not.

                    var isLeftDiagonalPrime = NumberProcessor.IsPrime(leftDiagonalVectorStrategy.GetNext(vector, lookupTable)); //Check if the left-diag adjacent is a prime or not.

                    var comparison = isPrime.CompareTo(isRightDiagonalPrime); //First comparison. This will compare the vectors to decide which way the path should move.

                    var comparisonWithOther = isPrime.CompareTo(isLeftDiagonalPrime); //Second comparison. We use partial comparison in here. We need that because we have more than 2 adjacents.

                    if (isPrime == false) 
                    {
                        //The thing is, if isPrime is false and if both comparison results return same value therefore whole of the three adjacents are non-primes.

                        var downAdjacent = downVectorStrategy.GetNext(vector, lookupTable); //We get the down.

                        if (comparison == 0 && comparisonWithOther == 0)
                        {

                            var rightAdjacent = rightDiagonalVectorStrategy.GetNext(vector, lookupTable); //We get the right diagonal.

                            var leftAdjacent = leftDiagonalVectorStrategy.GetNext(vector, lookupTable); //We get the left diagonal.

                            //Here, to add the next number to the sum, we need to get the maximum value between them.
                            var max = Math.Max(downAdjacent.magnitude, Math.Max(rightAdjacent.magnitude, leftAdjacent.magnitude));

                            //After finding maximum, we find which vector's magnitude is same with the maximum. Then assign it's vector to the current.
                            if (max == downAdjacent.magnitude)
                            {
                                vector = downAdjacent; 
                            }

                            else if (max == rightAdjacent.magnitude)
                            {
                                vector = rightAdjacent;
                            }

                            else
                            {
                                vector = leftAdjacent;
                            }

                        } //Both three adjacents are non-prime.

                        else if (comparisonWithOther == 0) //If only this comparison is zero then it means we work only with the left and down adjacents.
                        {   
                            var leftAdjacent = leftDiagonalVectorStrategy.GetNext(vector, lookupTable);

                            var max = Math.Max(downAdjacent.magnitude, leftAdjacent.magnitude);

                            if (max == downAdjacent.magnitude)
                            {
                                vector = downAdjacent;
                            }

                            else
                            {
                                vector = leftAdjacent;
                            }
                        } //IsPrime is false so downAdjacent is a non-prime. comparisonWithOther = 0 so then left diagonal also is a non-prime.

                        else if (comparison == 0) //If only this comparison is zero then it means we work only with the right and down adjacents.
                        {
                            var rightAdjacent = rightDiagonalVectorStrategy.GetNext(vector, lookupTable);

                            var max = Math.Max(downAdjacent.magnitude, rightAdjacent.magnitude);
                            
                            if (max == downAdjacent.magnitude)
                            {
                                vector = downAdjacent;
                            }

                            else
                            {
                                vector = rightAdjacent;
                            }
                        } //Down adjacent and right diagonal adjacent are non-primes.
                    }

                    else // The situation where the downAdjacent is a prime.
                    {
                        if (comparisonWithOther > 0) //Down adjacent is a prime, left diagonal is a non-prime.
                        {
                            var leftAdjacent = leftDiagonalVectorStrategy.GetNext(vector, lookupTable);
                            
                            if (comparison == 0) //Down adjacent is a prime, right diagonal is a prime.
                            {
                                vector = leftAdjacent;
                            }

                            else if (comparison > 0) //Down adjacent is a prime, both left and right ones are non-primes.
                            {
                                var rightAdjacent = rightDiagonalVectorStrategy.GetNext(vector, lookupTable);

                                var max = Math.Max(rightAdjacent.magnitude, leftAdjacent.magnitude);

                                if (max == rightAdjacent.magnitude)
                                {
                                    vector = rightAdjacent;
                                }

                                else
                                {
                                    vector = leftAdjacent;
                                }
                            }
                        }

                        else if (comparison > 0) //Down adjacent is a prime but right diagonal adjacent is not.
                        {
                            var rightAdjacent = rightDiagonalVectorStrategy.GetNext(vector, lookupTable);

                            if (comparisonWithOther == 0) //Down and left are both primes.
                            {

                                vector = rightAdjacent;
                            } //
                            
                            else if (comparisonWithOther > 0) //Down is prime, only the left is not.
                            {
                              
                                var leftAdjacent = leftDiagonalVectorStrategy.GetNext(vector, lookupTable);

                                vector = leftAdjacent;
                            }
                        }
                    }

                }
                
                sum += vector.magnitude; //Finally, adds the next vector's magnitude to the sum.

                Console.WriteLine($"\nAdded number to the sum: {vector.magnitude}");

                Console.WriteLine($"Sum: {sum}");

                
            }
            Console.WriteLine("\nPress any key to exit.");

            ConsoleKeyInfo? key = Console.ReadKey(true);

            if (key != null)
            {
                Environment.Exit(1);
            }
        }
    }       
}
