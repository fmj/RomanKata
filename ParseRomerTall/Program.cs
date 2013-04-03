using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseRomerTall
{
    class Program
    {
        static void Main(string[] args)
        {
            ParseRomer romer = new ParseRomer();
            while (true)
            {
                for (int i = 0; i <= 3999; i++)
                {
                    var romerRes = romer.Parse(i);
                    Console.WriteLine(string.Format("i={0},Roman={1}", i, romerRes));
                  
                }
                Console.ReadLine();
            }
         
        }
    }
}
