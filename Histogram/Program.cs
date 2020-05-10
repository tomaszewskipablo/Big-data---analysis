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

                bool isI=true;
                if (letter == 'I')
                    isI = true;
                else if (letter == 'Z')
                    isI = false;

                histogram = new Histogram(binSize);

                GetDataFromBinaryFile(minX, maxX, minY, maxY, memoryUsage, isI);



                histogram.MakeIntervals();
                histogram.CalculateKForIntervals();
                histogram.FilfullIntervals();
                histogram.CalculateAllVariables();
                histogram.WriteToConsoleStatistics();
            }

        }
        public static void GetDataFromBinaryFile(double minX, double maxX, double minY, double maxY, int size, bool isI)
        {
            
            double X;
            int chukCounter = 0;
            byte[] chunk;



            using (BinaryReader reader = new BinaryReader(File.Open("data.bin", FileMode.Open)))
            {
                do
                {
                    chunk = reader.ReadBytes(size);
                    //check untill 
                    X = BitConverter.ToDouble(chunk, size-26); // get last element in chunk
                    chukCounter++;
                    Console.WriteLine(minX - X);
                } while (X < minX);

                
                int change = size / 2;
                int position = size / 2; // middle
                position = position + position % 26;
                do
                {
                    
                    change = change / 2;
                    change = change - change % 26;
                    if(change < 26)
                    {
                        change = 26;
                    }


                    // try to find boundaries
                    X = BitConverter.ToDouble(chunk, position);
                    Console.WriteLine(minX - X);
                    if (minX <= X && X < maxX)
                    {
                        // We are in the right place now, go up
                        do
                        {
                            position -= 26;                            
                            X = BitConverter.ToDouble(chunk, position);
                            Console.WriteLine(minX - X);
                            if (X < minX)
                            {
                                break;                                
                            }
                        } while (true);
                        //We are on minimum
                        do
                        {
                            if (X > maxX)
                            {
                                position -= 26;
                                return;
                            }
                            if (position >= size - 26)
                            {
                                chunk = reader.ReadBytes(size);
                                position =-26;
                            }
                            // ADDING POINTS
                            position += 26;
                            X = BitConverter.ToDouble(chunk, position);
                            
                            
                            
                            // ADD POINT
                            double value=0;

                            
                            double Y = BitConverter.ToDouble(chunk, position+8);
                            
                            if (minY <= Y && Y < maxY)
                            {
                                // ADD Z OR I
                                if (isI)
                                {
                                    value = BitConverter.ToInt16(chunk, position + 24); // I
                                }
                                else
                                {
                                    value = BitConverter.ToDouble(chunk, position + 16); // Z
                                }
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
