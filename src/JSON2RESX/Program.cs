using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON2RESX
{
    class Program
    {
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(args[0]) || string.IsNullOrEmpty(args[1]))
            {
                Console.WriteLine("USAGE: JSON2RESX.exe jsonFile resxFile");
            }
            else JsonResxConverter.Convert(args[0], args[1]);
        }
    }
}
