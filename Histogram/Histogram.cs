using System;
using System.Collections.Generic;

namespace Histogram
{
    public class Histogram
    {
        public int binSize = 0;
        public int count = 0;
        public double min = double.MaxValue;
        public double max = double.MinValue;

        public double n;

        List<double> numbers = new List<double>();
        List<Interval> intervals = new List<Interval>();
        public Histogram(int binSize)
        {
            this.binSize = binSize;
        }

        public void InsertValue<T>(T value)
        {
            count++;

            double v = Convert.ToDouble(value);
            numbers.Add(v);

            if (v < min)
            {
                min = v;
            }

            if (v > max)
            {
                max = v;
            }
        }
        public void MakeIntervals()
        {
            double numberOfIntervals = Convert.ToInt32((max - min) / binSize + 1);
            for (int i = 0; i < numberOfIntervals; i++)
            {
                double minRange = min + binSize * (i);
                double maxRange = minRange + binSize;

                intervals.Add(new Interval(minRange, maxRange));
            }
        }
        public void FilfullIntervals()
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int interval = 0; interval < intervals.Count; interval++)
                {
                    if (intervals[interval].minRange <= numbers[i] && intervals[interval].maxRange > numbers[i])
                    {
                        intervals[interval].values.Add(numbers[i]);
                        break;
                    }
                }
            }
        }
        
        public void CalculateKForINtervals()
        {
            foreach (var interval in intervals)
            {
                interval.CalculateK(binSize);
            }
        }
        //public void CalculateN()
        //{
        //    foreach (var interval in intervals)
        //    {
        //        interval.
        //    }
        //}

        
    }
}