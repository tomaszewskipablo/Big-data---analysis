using System;
using System.Collections.Generic;
using System.Text;

namespace Histogram
{
    
    class Interval
    {
        public double K=0;
        public int H=0;
        public double minRange;
        public double maxRange;
        public List<double> values = new List<double>();

        public Interval(double minRange, double maxRange)
        {
            this.minRange = minRange;
            this.maxRange = maxRange;
        }
        public void CalculateK(int bin_size)
        {
            K = minRange + bin_size / 2;
        }
    }
}
