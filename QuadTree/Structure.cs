using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System.Runtime.InteropServices.ComTypes;

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


        public void GetDataFromBinaryFile(double minX, double maxX)
        {
            List<Point> p = new List<Point>();
            
            double X; 
            int counter = 2;
            int size = numerOfLines * 26;
            size = size + size % 26;
            int change=size/2;
            int position = size / 2; // middle
            
            using (BinaryReader reader = new BinaryReader(File.Open("data.bin", FileMode.Open)))
            {
                
                do
                {
                    change = change / 2;
                    change= change + change % 26;

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
                                position += 26;
                                break;
                            }
                            // ADD POINT
                            Point point = new Point();
                            point.Position.X = X;
                            point.Position.Y = reader.ReadDouble();
                            point.Z = reader.ReadDouble();
                            point.I = reader.ReadInt16();
                            p.Add(point);


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
