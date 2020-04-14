using System;
namespace Histogram
{
    public class Histogram
    {
        public int BinSize = 0;
        public int Count = 0;
        public double Min = double.MaxValue;
        public double Max = double.MinValue;

        public Histogram(int binSize)
        {
            BinSize = binSize;
        }

        public void InsertValue<T>(T value)
        {
            Count++;

            double v = Convert.ToDouble(value);

            if (v < Min)
            {
                Min = v;
            }

            if (v > Max)
            {
                Max = v;
            }
        }
    }
}