using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Result
    {
        public static double GetNumber()
        {
            try
            {
                return Convert.ToDouble(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("You've entered incorrect number format! Program will be closed.");
                Console.ReadKey();
                Environment.Exit(0);
                return 0;
            }
        }
    }
        class Determinant
    {
        static void Main()
        {
            Console.WriteLine("The task is to find Determinant for given 3x3 matrix.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine("Please Enter matrix 3x3 elements:");
            Console.WriteLine("a11 a12 a13");
            Console.WriteLine("a21 a22 a23");
            Console.WriteLine("a31 a32 a33");
            double[,] Matrix = new double[3, 3];
            for (int i = 0; i <= 2; i++)
            {
                for (int k = 0; k <= 2; k++)
                {
                    Console.Write("Please enter a{0}{1}: ",i+1,k+1);
                    Matrix[i,k] = Result.GetNumber();
                }
            }
            double result = Matrix[0, 0] * Matrix[1, 1] * Matrix[2, 2] + Matrix[0, 1] * Matrix[1, 2] * Matrix[2, 0] + Matrix[1, 0] * Matrix[2, 1] * Matrix[0, 2] - Matrix[2, 0] * Matrix[1, 1] * Matrix[0, 2] - Matrix[0, 1] * Matrix[1, 0] * Matrix[2, 2] - Matrix[0, 0] * Matrix[1, 2] * Matrix[2, 1];
            Console.WriteLine("Matrix Determinant is: {0}", result);
            Console.ReadKey();
        }
    }
}