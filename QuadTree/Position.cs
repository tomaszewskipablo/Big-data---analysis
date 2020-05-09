using System;
namespace QuadTree
{
    public class Position : IComparable
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }

        public int CompareTo(object obj)
        {

            Position otherPosition = (Position)obj;
            
            if (this.X< otherPosition.X)
            {
                return -1;
            }
            else if(this.X < otherPosition.X)
            {
                return 1;
            }
            else
            {
                return 1;
            }
        }
    }
}