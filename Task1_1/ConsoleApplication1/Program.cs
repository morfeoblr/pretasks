using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
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
        public static double Addition(double X, double Y)
        {
            return X + Y;
        }
        public static double Subtraction(double X, double Y)
        {
            return X - Y;
        }
        public static double Multiplication(double X, double Y)
        {
            return X * Y;
        }
        public static double Division(double X, double Y)
        {
            return X / Y;
        }
    }
    class ToCalculate
    {
        static void Main()
        {
            Console.Write("Please enter first number: ");
            double X = Result.GetNumber();
            Console.Write("Please enter desired operation (allowed are: *, /, -, +): ");
            string operation = Console.ReadLine();
            Console.Write("Please enter second number: ");
            double Y = Result.GetNumber();
            switch (operation)
            {
               case "*":
                    Console.Write("The result is calculated: {0} {1} {2} = {3}", X, operation, Y, Result.Multiplication(X,Y));
                    Console.ReadKey();
                    break;
               case "/":
                    if (Y != 0)
                    {
                        Console.Write("The result is calculated: {0} {1} {2} = {3}", X, operation, Y, Result.Division(X, Y));
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Write("Sorry, I can't divide {0} by zero.", X);
                        Console.ReadKey();
                    }
                    break;
               case "-":
                    Console.Write("The result is calculated: {0} {1} {2} = {3}", X, operation, Y, Result.Subtraction(X, Y));
                    Console.ReadKey();
                    break;
               case "+":
                    Console.Write("The result is calculated: {0} {1} {2} = {3}", X, operation, Y, Result.Addition(X, Y));
                    Console.ReadKey();
                    break;
               default:
                    Console.WriteLine("You've entered not supported operation. Sorry, the program will be closed.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}