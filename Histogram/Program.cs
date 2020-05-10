using System;
using System.IO;

namespace Histogram
{
    class Program
    {
        static Histogram histogram;
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

                histogram = new Histogram(binSize);


                GetDataFromBinaryFile(minX, maxX, minY, maxY, memoryUsage);



                histogram.MakeIntervals();
                histogram.CalculateKForIntervals();
                histogram.FilfullIntervals();
                histogram.CalculateAllVariables();
                histogram.WriteToConsoleStatistics();
            }

        }
        public static void GetDataFromBinaryFile(double minX, double maxX, double minY, double maxY, int size)
        {
            
            double X;
            int counter = 2;
            
            size = size + size % 26;
            int change = size / 2;
            int position = size / 2; // middle
            position = position + position % 26;

            using (BinaryReader reader = new BinaryReader(File.Open("data.bin", FileMode.Open)))
            {

                do
                {
                    change = change / 2;
                    change = change - change % 26;
                    if(change < 26)
                    {
                        change = 26;
                    }

                    reader.BaseStream.Position = position; // middle
                    Console.WriteLine(position+ "   ");
                    X = reader.ReadDouble();
                    if (minX <= X && X < maxX)
                    {
                        // We are in the right place now, go up
                        do
                        {
                            position -= 26;
                            reader.BaseStream.Position = position;
                            X = reader.ReadDouble();
                            if (X < minX)
                            {
                                break;
                            }
                        } while (true);
                        //We are on minimum
                        do
                        {

                            position += 26;
                            reader.BaseStream.Position = position;
                            X = reader.ReadDouble();
                            if (X > maxX)
                            {
                                position -= 26;
                                break;
                            }
                            // ADD POINT
                            double value;

                            double Y = reader.ReadDouble();
                            value = reader.ReadDouble(); // Z
                            value = reader.ReadInt16(); // I
                            if (minY < Y && Y < maxY)
                            {
                                histogram.InsertValue(value);
                            }

                        } while (true);
                    }
                    else if (maxX <= X) // we are too far
                    {
                        position -= change;
                    }
                    else
                    {
                        position += change;
                    }

                } while (true);
            }
        }
    }
}
