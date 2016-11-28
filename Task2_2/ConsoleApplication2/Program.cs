using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayAndLinkedList.ComparisonofArrayAndLinkedList();
            Console.WriteLine("\n");
            StackAndQueue.ComparisonofStackAndQueue();
            Console.WriteLine("\n");
            HashTableAndDictionary.ComparisonofHashTableAndDictionary();
            Console.ReadKey();
        }
    }
}