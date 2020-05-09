using System;
using System.Collections.Generic;
using System.IO;

namespace Histogram
{
    public class Histogram
    {
        public int binSize = 0;
        public int numberOfPoints = 0;
        public double min = double.MaxValue;
        public double max = double.MinValue;

        public double average;
        public double deviation;
        public double skewness;
        public double kurtosis;

        List<double> numbers = new List<double>();
        List<Interval> intervals = new List<Interval>();
        public Histogram(int binSize)
        {
            this.binSize = binSize;
        }
        public void GetDataFromBinaryFile(double minX, double maxX, double minY, double maxY)
        {
            int numerOfLines = 1536;
            double X;
            int counter = 2;
            int size = numerOfLines * 26;
            size = size + size % 26;
            int change = size / 2;
            int position = size / 2; // middle

            using (BinaryReader reader = new BinaryReader(File.Open("data.bin", FileMode.Open)))
            {

                do
                {
                    change = change / 2;
                    change = change + change % 26;

                    reader.BaseStream.Position = position; // middle
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
                                InsertValue(value);
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
        public void InsertValue<T>(T value)
        {
            numberOfPoints++;

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
                        intervals[interval].H++;
                        break;
                    }
                }
            }
        }

        public void CalculateKForIntervals()
        {
            foreach (var interval in intervals)
            {
                interval.CalculateK(binSize);
            }
        }
        public void CalculateAverage()
        {
            double nominator = 0, denominator = 0;

            for (int i = 0; i < intervals.Count; i++)
            {
                nominator += intervals[i].H * intervals[i].K;
                denominator += intervals[i].H;
            }
            average = nominator / denominator;
        }
        public void CalculateDeviation()
        {
            double nominator = 0, denominator = 0;
            for (int i = 0; i < intervals.Count; i++)
            {
                nominator += intervals[i].H * Math.Pow(intervals[i].K - average, 2);
                denominator += intervals[i].H;

            }
            deviation = Math.Sqrt(nominator / denominator);
        }
        public void CalculateSkewness()
        {
            double nominator = 0, denominator = 0;
            double nominatorSub = 0, denominatorSub = 0;
            for (int i = 0; i < intervals.Count; i++)
            {
                nominatorSub += intervals[i].H * Math.Pow(intervals[i].K - average, 3);
                denominatorSub += intervals[i].H;

            }
            nominator = nominatorSub / denominatorSub;

            nominatorSub = 0; denominatorSub = 0;
            for (int i = 0; i < intervals.Count; i++)
            {
                nominatorSub += intervals[i].H * Math.Pow(intervals[i].K - average, 2);
                denominatorSub += intervals[i].H;              
            }
            denominatorSub--;

            denominator = (Math.Pow(nominatorSub / denominatorSub,1.5));

            skewness = nominator / denominator;
        }
        public void CalculateKurtosis()
        {
            double nominator = 0, denominator = 0, factor = 0;
            for (int i = 0; i < intervals.Count; i++)
            {
                nominator += intervals[i].H * Math.Pow(intervals[i].K - average, 4);
                denominator +=intervals[i].H * Math.Pow(intervals[i].K - average, 2);
                factor += intervals[i].H;
            }
            denominator = Math.Pow(denominator, 2);
            kurtosis = factor * nominator / denominator;
        }
        public void CalculateAllVariables()
        {
            CalculateAverage();
            CalculateDeviation();
            CalculateSkewness();
            CalculateKurtosis();
        }
        public void WriteToConsoleStatistics()
        {

            Console.WriteLine("Number of points inside given bounding box: " + numberOfPoints);
            Console.WriteLine("Calculated average: " + average);
            Console.WriteLine("Calculated deviation: " + deviation);
            Console.WriteLine("Calculated skewness: " + skewness);
            Console.WriteLine(" Calculated kurtosis: " + kurtosis);
        }


    }
}