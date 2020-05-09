using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            Histogram histogram = new Histogram(4); // create histogram with bin size
            double d1 = 394372.50, d2 = 394372.55;
            double y1 = 39175.79, y2 = 39178.79;
            histogram.GetDataFromBinaryFile(d1, d2, y1, y2);

            // Histogram .....
          
            
            //histogram.InsertValue(1);
            //histogram.InsertValue(2);
            //histogram.InsertValue(3);
            //histogram.InsertValue(2);
            //histogram.InsertValue(2);
            //histogram.InsertValue(1);
            //histogram.InsertValue(14);
            //histogram.InsertValue(5);
            //histogram.InsertValue(16);
            //histogram.InsertValue(20);
            //histogram.InsertValue(21);
            //histogram.InsertValue(22);
            //histogram.InsertValue(25);

            histogram.MakeIntervals();
            histogram.CalculateKForIntervals();
            histogram.FilfullIntervals();
            histogram.CalculateAllVariables();
            histogram.WriteToConsoleStatistics();
        }
    }
}
