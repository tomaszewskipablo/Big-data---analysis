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
            
        }

    }
}
