using System;
using System.Collections.Generic;
using System.IO;

namespace QuadTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Structure structure = new Structure();
            structure.ReadFromFile();
            structure.SaveAsBinaryFile();
            double d1= 394372.50, d2 = 394372.55;
            double y1 = 39175.79, y2 = 39178.79;
            structure.GetDataFromBinaryFile(d1, d2, y1, y2);
            
            // Histogram .....
        }

    }
}
