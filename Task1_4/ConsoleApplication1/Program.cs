using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Result
    {
        public static int GetNumber()
        {
            try
            {
                return Convert.ToInt32(Console.ReadLine());
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
        class SecondBiggestString
    {
        static void Main()
        {
            Console.WriteLine("The task is to revert strings of given list. Let's get initial strings!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Write("Please Enter number of string items that you want to enter: ");
            int i = Result.GetNumber();
            while (i <= 1)
            {
                Console.Write("Please Enter 2 or more strings to enter: ");
                i = Result.GetNumber();
            }
            List<string> Strings = new List<string>();
            for (int k = 1; k <= i; k++)
            {
                Console.WriteLine("Please enter string #{0}", k);
                string temp = Convert.ToString(Console.ReadLine());
                while (temp.Length <= 1)
                {
                    Console.Write("Please Enter 2 or more symbols four your string: ");
                    Console.WriteLine("Please enter string #{0}", k);
                    temp = Convert.ToString(Console.ReadLine());
                }
                Strings.Add(temp);
            }
            Console.WriteLine("Here is the result:");
            for (int k = 0; k <= i-1; k++)
            {
                for (int j = 0; j < Strings[k].Length; j++)
                {
                    Console.Write("{0}", Strings[k][Strings[k].Length - j - 1]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}