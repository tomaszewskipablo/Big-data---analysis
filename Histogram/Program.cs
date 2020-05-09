using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 8)
            {
                System.Console.WriteLine("Plese run program:\n program <preprocessed_file> <M> <minX> <maxX> <minY> <maxY> <bin_size> <selection>");
                return;
            }
            else
            {
                // read user parameters
                string fileName = args[0];
                int M = int.Parse(args[1]);

                int memoryUsage = 999986 * M;

                double minX = Double.Parse(args[2]);
                double maxX = Double.Parse(args[3]);
                double minY = Double.Parse(args[4]);
                double maxY = Double.Parse(args[5]);
                int binSize = int.Parse(args[6]);
                char letter = char.Parse(args[7].ToUpper());

                bool isI;
                if (letter == 'I')
                    isI = true;
                else if (letter == 'Z')
                    isI = false;

                Histogram histogram = new Histogram(binSize);


                histogram.GetDataFromBinaryFile(minX, maxX, minY, maxY);



                histogram.MakeIntervals();
                histogram.CalculateKForIntervals();
                histogram.FilfullIntervals();
                histogram.CalculateAllVariables();
                histogram.WriteToConsoleStatistics();
            }
        }
    }
}
