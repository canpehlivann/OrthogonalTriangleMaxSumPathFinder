using System;
using System.Collections.Generic;

namespace OrthogonalTrianglePathMaxSum
{
    public class OrthogonalTriangleProcessor
    {

        public static List<int> ReadOrthogonalTriangleFromFile(string filePath) // It reads the whole orthogonal triangle and returns a 2D vector                                                                        
        {

            List<int> triangleList = new List<int>(); //Creates empty list. This list will hold the numbers that are the elements of the triangle.
            
            try
            {
                //Method will read the file line by line. And then takes the elements of current line
                //and splits them based on delimiter space character and parses them into a number and
                //then finally puts them into the list.

                var lines = File.ReadLines(filePath) 
                    .Select(line => line.Split(' ').Select(int.Parse).ToArray())
                    .ToArray();

                foreach (var elements in lines)
                {
                    triangleList.AddRange(elements);
                }
            } 
            
            catch( Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return triangleList;
        }

        public static int CountLinesFromFile(string filePath)
        {
            // It returns the count of lines in the triangle file.

            return File.ReadLines(filePath).Count();
        }

        internal static List<Vector2> ConvertToVector2(List<int> numbers)
        {
            List<Vector2> vectors = new List<Vector2>(); //Creates empty list that is type of Vector2.

            int currentX = 0;
            int currentY = 0;

            //For each element in the list, it will basically convert the current element of the triangleList into a Vector2 which has coordinates.
            //Coordinates start from 0,0 and each one of them addresses a number in the triangleList.
            //Then it adds that Vector2 to the Vector2 list.
            foreach (var number in numbers)
            {
                Vector2 vector = new Vector2(currentX,currentY,number);
                vectors.Add(vector);

                // Move to the next row when reach the end of the current row
                if (currentX == currentY)
                {
                    currentX = 0;
                    currentY++;
                }
                else
                {
                    currentX++;
                }
            }

            return vectors;
        }

        internal static Dictionary<Coordinates,Vector2> CreatelookupTable(List<Vector2> vectorList)
        {
            //Creates the Lookup Table.
            Dictionary<Coordinates,Vector2> lookupTable = new Dictionary<Coordinates,Vector2>();

            //Add all elements in the vector list to the lookupTable. 
            foreach (var vector in vectorList)
            {
                lookupTable.TryAdd(Vector2.GetCoordinatesFromVector(vector), vector);
            }

            return lookupTable;
        }

        internal static bool IsPrime(int number)
        {
            if ((number % 1) == 0) //Checks if the number is even or not. (LSB way.)
            {
                if (number == 2) //If it is two, which is the number that is the only prime in even numbers.
                {
                    return true;
                }

                else
                {
                    // The idea of using Sqrt() function below is,
                    // for a positive integer N, if N is not divisible by a prime
                    // less than square root of N, then N is a prime number.
                    // So, we are not checking all of the divisors of the number N.

                    var squareRootOfNumber = Math.Sqrt(number);

                    for (int i = 2; i <= squareRootOfNumber; i++) 
                    {
                        if (number % i == 0) //If a number is divisible by one of the numbers that is less than
                                             //square root of number, then number is not a prime. Return false.
                        {
                            return false;
                        }
                    }
                }
            }

            return true; //Otherwise, if the number is prime, return true.

        }

        internal void ProcessStrategies(List<IVectorStrategy> strategy, ref Vector2 vec, Dictionary<Coordinates, Vector2> lookupTable, ref int sum)
        {
            
        }    
    }
}