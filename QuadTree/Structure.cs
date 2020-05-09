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

 

    }
}
