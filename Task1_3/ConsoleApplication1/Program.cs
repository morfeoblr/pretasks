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
            Console.WriteLine("The task is to find string with 2nd max length. Let's get initial strings!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Write("Please Enter number of string items that you want to enter: ");
            int i = Result.GetNumber();
            while (i <= 1)
            {
                Console.Write("Please Enter 2 or more strings to enter: ");
                i = Result.GetNumber();
            }
            List<string> strings = new List<string>();
            for (int k = 1; k <= i; k++)
            {
                Console.WriteLine("Please enter string #{0}", k);
                string temp = Convert.ToString(Console.ReadLine());
                while (temp.Length <= 0)
                {
                    Console.Write("Please Enter 1 or more symbols for your string: ");
                    Console.WriteLine("Please enter string #{0}", k);
                    temp = Convert.ToString(Console.ReadLine());
                }
                strings.Add(temp);
            }

            Sorting.BubbleSort(strings);
            Console.WriteLine("Next string has 2nd max length in {0} symbols:", strings[1].Length);
            Console.WriteLine("{0}", strings[1]);
            Console.ReadKey();
        }
    }
}