using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("New complex number using constructor ------------------");
            ComplexFunctional c = new ComplexFunctional(1, 30);
            Console.WriteLine("c = " + c);
            Console.WriteLine();
            Console.WriteLine("New complex number using static method ----------------");
            Console.WriteLine("Complex with static: "+ ComplexFunctional.AbsandArgCreate(1,30));
            Console.WriteLine();
            Console.WriteLine("Property example-----------------------------");
            Console.WriteLine("Real part of c is " + c.Real + ".");
            Console.WriteLine("Imaginary part of c is " + c.Imaginary + ".");
            Console.WriteLine();
            Console.WriteLine("Calculable properties -----------------");
            Console.WriteLine("Complex number abs is " + c.ComplexAbs + ".");
            Console.WriteLine("Comlex number argument is (in pi-radians) " + c.ComplexArg + ".");
            Console.WriteLine();
            Console.WriteLine("Some other calculations -------------------------");
            ComplexFunctional c1 = new ComplexFunctional(2, 3);
            Console.WriteLine("c + c1 = " + (c+c1));
            Console.WriteLine("c - c1 = " + (c-c1));
            Console.WriteLine("c * c1 = " + (c*c1));
            Console.WriteLine("c / c1 = " + (c/c1));
            Console.WriteLine();
            Console.WriteLine("Complex equality----------------");
            Console.WriteLine(c == c1);
            Console.WriteLine();
            Console.WriteLine("Type transformation --------------------");
            ComplexFunctional c2 = 7;
            Console.WriteLine(c2);
            Console.WriteLine();
            Console.WriteLine("String overriding");
            ComplexFunctional c3 = new ComplexFunctional(0,1);
            ComplexFunctional c4 = new ComplexFunctional(1, 0);
            ComplexFunctional c5 = new ComplexFunctional(0, -1);
            Console.WriteLine(c3 + ", " + c4 + ", " + c5);
            Console.ReadKey();
        }
    }
}
