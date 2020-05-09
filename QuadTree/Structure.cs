using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;

namespace QuadTree
{
    class Structure
    {
        public SortedList<double, Point> Data = new SortedList<double, Point>();

        public void ReadFromFile()
        {
            try
            {
                // Read file using StreamReader. Reads file line by line    
                using (StreamReader file = new StreamReader("input.txt"))
                {
                    int counter = 0;
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {

                        string[] tokens = ln.Split(' ');
                        Data.Add(Convert.ToDouble(tokens[0]), new Point(Convert.ToDouble(tokens[0]), Convert.ToDouble(tokens[1]), Convert.ToDouble(tokens[2]), Convert.ToInt16(tokens[3])));

                        counter++;
                    }
                    file.Close();

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void SaveAsBinaryFile()
        {            
            using (BinaryWriter writer = new BinaryWriter(File.Open("data.bin", FileMode.Create)))
            {
                foreach (KeyValuePair<double, Point> kvp in Data)
                {
                    writer.Write(kvp.Value.Position.X);
                    writer.Write(kvp.Value.Position.Y);
                    writer.Write(kvp.Value.Z);
                    writer.Write(kvp.Value.I);
                }
            }
        }


        public void GetDataFromBinaryFile(double d1, double d2)
        {
            double X;
            double Y;
            double Z;
            double I;


            using (BinaryReader reader = new BinaryReader(File.Open("data.bin", FileMode.Open)))
            {
                X = reader.ReadDouble();
                Y = reader.ReadDouble();
                Z = reader.ReadDouble();
                I = reader.ReadInt16();
            }

            Console.WriteLine("X: " + X);
            Console.WriteLine("Y: " + Y);
            Console.WriteLine("Z: " + Z);
            Console.WriteLine("I: " + I);
        }
    }
}
