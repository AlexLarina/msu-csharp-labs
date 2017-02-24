using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace JaggedExample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // N - размерность матриц
            const int ALines = 5, AColumns = 2, BLines = 2, BColumns = 5;
            double[][] A = new double[ALines][];
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = new double[AColumns];
            }
            Console.WriteLine("First matrix__________");
            Random rand = new Random();
            for (int i = 0; i < ALines; i++)
            {
                for (int j = 0; j < A[i].Length; j++)
                {
                    A[i][j] = rand.NextDouble();
                    Console.Write("{0:0.00} ", A[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            double[][] B = new double[BLines][];
            for (int i = 0; i < B.Length; i++)
            {
                B[i] = new double[BColumns];
            }
            Console.WriteLine("Second matrix__________");
            for (int i = 0; i < BLines; i++)
            {
                for (int j = 0; j < B[i].Length; j++)
                {
                    B[i][j] = rand.NextDouble();
                    Console.Write("{0:0.00} ", B[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Their multiplication__________");

            double[][] C = new double[AColumns][];
            for (int i = 0; i < C.Length; i++)
            {
                C[i] = new double[BLines];
            }

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < AColumns; i++)
            {
                for (int j = 0; j < BLines; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < AColumns; k++)
                    {
                        temp += A[i][k] + B[k][j];
                    }
                    C[i][j] = temp;
                    Console.Write("{0:0.00} ", C[i][j]);
                }
                Console.WriteLine();
            }
            sw.Stop();
            long duration = sw.ElapsedMilliseconds;
            Console.WriteLine("Multiplication time " + duration + ".");
            duration = duration * 1000;
            // Количество операций оценивается по размеру квадратных матриц. Оценим число операций сверху. 
            // А раз матрицы у нас прямоугольные, вместо n возьмем максимальный длину/высоту одной из матриц
            int max = AColumns;
            if (AColumns <= ALines)
            {
                max = ALines;
                if (ALines <= BLines)
                {
                    max = BLines;
                }
            }
            else
            {
                if (AColumns <= BLines)
                {
                    max = BLines;
                }
            }
            Console.WriteLine("The max size is " + max + ".");
            double Operationnumber = 2 * (int)Math.Pow((double)max, 3.0);
            Console.WriteLine("The number of operations is about " + Operationnumber + ".");
            double productivity = Operationnumber / (duration * 1000);
            Console.WriteLine("The productivity is " + productivity + ".");

            Console.ReadKey();
        }
    }
}
