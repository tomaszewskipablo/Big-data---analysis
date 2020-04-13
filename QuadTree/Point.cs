using System;
using System.Collections.Generic;
using System.Text;

namespace QuadTree
{
    public class Point
    {
        double x;
        double y;
        double z;
        short i;
        public Point()
        {
        }
        public Point(double x, double y, double z, short i)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.i = i;
        }
    }
}

