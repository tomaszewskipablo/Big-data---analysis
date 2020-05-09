using System;
namespace QuadTree
{
    public class Point
    {
        public Position Position { get; set; }
        public double Z { get; set; }
        public short I { get; set; }


        public Point(double x, double y, double z, short i)
        {
            Position position = new Position(x, y);
            Position = position;
            Z = z;
            I = i;
        }

        public Point(Position p, double z, short i)
        {
            Z = z;
            I = i;
            Position = p;
        }
        public Point(Point point)
        {
            Position position = new Position(point.Position.X, point.Position.Y);
            Position = position;
            Z = point.Z;
            I = point.I;
        }
    }
}