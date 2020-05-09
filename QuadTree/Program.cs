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
            double d1=2, d2 = 1;
            structure.GetDataFromBinaryFile(d1, d2);
            
            // Histogram .....
        }

    }
}
