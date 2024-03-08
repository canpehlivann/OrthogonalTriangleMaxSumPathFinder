using System;
using System.Collections.Generic;

namespace OrthogonalTrianglePathMaxSum
{
    //This object is a representation of a (x,y) coordinate. This will be used in mapping of the triangle elements list
    //to coordinates. This is a vector that has magnitude as the representation of a number in the triangle.
    
    internal class Vector2 : Coordinates
    {
        
        public int magnitude { get; set; } // This represents numbers in the triangleList.

        public Vector2 (int x, int y, int magnitude) : base(x,y)
        {
            this.magnitude = magnitude;
        }

        public bool isPrime()
        {
            return NumberProcessor.IsPrime(this); //isPrime function uses the encapsulated IsPrime (NumberProcessor.IsPrime) for simplifying the application.
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode(), magnitude).GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            // Do the type check.

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Vector2 other = (Vector2)obj;

            return base.Equals(obj) && magnitude == other.magnitude;
        }

        
        public Vector2 GetDown(Dictionary<Coordinates, Vector2> lookupTable) //Gets the current vector's adjacent(Down).
        {
            Vector2 vec = new Vector2(x, y, magnitude);

            vec.y += 1;

            return FindVectorByCoordinates(lookupTable, GetCoordinatesFromVector(vec)) // It is used to updating its magnitude.
                  ?? throw new InvalidOperationException("An error occurred while processing the file. Please check your file and try again.");
        }
        public Vector2 GetLeftDiagonal(Dictionary<Coordinates, Vector2> lookupTable)
        {
            Vector2 vec = new Vector2(x, y, magnitude);

            vec.x -= 1;
            vec.y += 1;

            return FindVectorByCoordinates(lookupTable, GetCoordinatesFromVector(vec))
                   ?? throw new InvalidOperationException("An error occurred while processing the file. Please check your file and try again.");
        } //Gets the current vector's adjacent(Left Diagonal). 

        public Vector2 GetRightDiagonal(Dictionary<Coordinates,Vector2> lookupTable)
        {
            Vector2 vec = new Vector2(x, y, magnitude);

            vec.x += 1;
            vec.y += 1;

            return FindVectorByCoordinates(lookupTable, GetCoordinatesFromVector(vec))
                  ?? throw new InvalidOperationException("An error occurred while processing the file. Please check your file and try again.");
        } //Gets the current vector's adjacent(RightDiagonal).
        
        //Finds a vector by looking up to it's coordinates from the lookupTable. Returns null if it can't find a one.
        public static Vector2? FindVectorByCoordinates(Dictionary<Coordinates,Vector2> lookupTable, Coordinates coordinate)
        {
            try
            {
                if (lookupTable.TryGetValue(coordinate, out Vector2? vec))
                {
                    if (vec != null)
                    {
                        return vec;
                    }
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }
            return null;
        }
        
        //Returns a coordinate object from the vector.
        public static Coordinates GetCoordinatesFromVector(Vector2 vec)
        {
            return new Coordinates(vec.x,vec.y);
        }
    
    }
}
