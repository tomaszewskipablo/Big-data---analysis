using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.CompilerServices;

namespace QuadTree
{
    class Structure
    {
        public SortedList<Position, Point> Data = new SortedList<Position, Point>();
        int numerOfLines = 0;

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
                        Position p = new Position(Convert.ToDouble(tokens[0]), Convert.ToDouble(tokens[1]));
                        
                        Data.Add(p, new Point(Convert.ToDouble(tokens[0]), Convert.ToDouble(tokens[1]), Convert.ToDouble(tokens[2]), Convert.ToInt16(tokens[3])));

                        counter++;
                    }
                    file.Close();
                    numerOfLines = counter;
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
                foreach (KeyValuePair<Position, Point> kvp in Data)
                {
                    writer.Write(kvp.Value.Position.X);
                    writer.Write(kvp.Value.Position.Y);
                    writer.Write(kvp.Value.Z);
                    writer.Write(kvp.Value.I);
                }
            }
        }


       

    }
}
