using System;
using System.Collections.Generic;
using System.IO;

namespace QuadTree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> nodes = new List<Point>();


            try
            {
                // Read file using StreamReader. Reads file line by line    
                using (StreamReader file = new StreamReader("input.txt"))
                {
                    int counter = 0;
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        Console.WriteLine(ln);
                        
                        if (counter % 2 == 0)
                        {
                            string[] tokens = ln.Split(' ');
                            nodes.Add(new Point(Convert.ToDouble(tokens[0]), Convert.ToDouble(tokens[1]), Convert.ToDouble(tokens[2]), Convert.ToInt16(tokens[3])));                           
                        }
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
        static Point[] function queryRange(Point range)
        {
            // Prepare an array of results
            Point [] pointsInRange;

            // Check objects at this quad level
            for (int p = 0; p < points.size; p++)
            {
                if (range.containsPoint(points[p]))
                    pointsInRange.append(points[p]);
            }

            // Terminate here, if there are no children
            if (northWest == null)
                return pointsInRange;

            // Otherwise, add the points from the children
            pointsInRange.appendArray(northWest->queryRange(range));
            pointsInRange.appendArray(northEast->queryRange(range));
            pointsInRange.appendArray(southWest->queryRange(range));
            pointsInRange.appendArray(southEast->queryRange(range));

            return pointsInRange;
        }
    }
}
