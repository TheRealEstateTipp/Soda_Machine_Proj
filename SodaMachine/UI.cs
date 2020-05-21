using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    static class UI
    {


        public static void PrintString(string output)
        {
            Console.WriteLine(output);
        }
        public static string GetUsertInput(string output)
        {
            Console.WriteLine(output);
            string input = Console.ReadLine();
            return input;
        }
    }
}
