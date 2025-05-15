using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1, fahrenheit;
            Console.Write("Ingrese una temperatura en celsius: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            fahrenheit = num1 * 1.8 + 32;
            Console.WriteLine("La temperatura es de " + fahrenheit + " fahrenheit");
            Console.ReadKey();
        }
    }
}
