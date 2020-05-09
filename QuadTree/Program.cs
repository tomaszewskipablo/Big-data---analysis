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
            double d1=1, d2 = 3;
            structure.GetDataFromBinaryFile(d1, d2);
            
            // Histogram .....
        }

    }
}
