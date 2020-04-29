using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinearEquation a = new LinearEquation("1 2 3");
            Console.WriteLine(a);
            Console.WriteLine($"{a[0]}  {a[1]}   {a[2]}");
        }
    }
}
