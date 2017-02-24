using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.GetEncoding();
            Console.WriteLine("Complex List:");
            StackList<Complex> complexList = new StackList<Complex>();
            Complex complex1 = new Complex(1, 2);
            Complex complex2 = new Complex(2, 3);
            complexList.Push(complex1);
            complexList.Push(complex2);
            complexList.Print();
            //Console.WriteLine("The number of elements in stack " + complexList.Count);
            Console.WriteLine("-----------------------------");
            complexList.Pop();
            complexList.Print();
            Console.ReadKey();
        }
    }
}
