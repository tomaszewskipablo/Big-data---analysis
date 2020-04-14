using System;
using System.Collections.Generic;
using System.Text;

namespace Histogram
{
    
    class Interval
    {
        public int H;
        public double minRange;
        public double maxRange;
        public List<double> values = new List<double>();

        public Interval(double minRange, double maxRange)
        {
            this.minRange = minRange;
            this.maxRange = maxRange;
        }
    }
}
