using System;
using System.Collections.Generic;

namespace OrthogonalTrianglePathMaxSum
{
    internal class Coordinates
    {
        public int x { get; set; }
        public int y { get; set; }

        //public (int x,int y) Coordinate { get; set; }
        public Coordinates(int x, int y) //(int x, int y) coordinate)
        {
            this.x = x;
            this.y = y;
           // this.Coordinate = coordinate;
        }
        public override int GetHashCode()
        {
            return (x, y).GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Coordinates other = (Coordinates)obj;

            return x == other.x && y == other.y;
        }

    }
}
