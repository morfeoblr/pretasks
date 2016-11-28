using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApplication2
{
    public class ArrayAndLinkedList
    {
        public static void ComparisonofArrayAndLinkedList()
        {
            Stopwatch stopWatch = new Stopwatch();
            ArrayList arrayList = new ArrayList();
            LinkedList<object> linkedList = new LinkedList<object>();

            Console.WriteLine("Operation add 500000 items");
            stopWatch.Start();
            for (int i = 0; i < 500000; i++)
            {
                arrayList.Add(i);
            }
            stopWatch.Stop();
            Console.WriteLine("ArrayList time - {0} ms", stopWatch.ElapsedMilliseconds);

            stopWatch.Reset(); stopWatch.Start();
            for (int i = 0; i < 500000; i++)
            {
                linkedList.AddLast(i);
            }
            stopWatch.Stop();
            Console.WriteLine("LinkedList time - {0} ms", stopWatch.ElapsedMilliseconds);

            Console.WriteLine("Operation Search");
            stopWatch.Reset(); stopWatch.Start();
            arrayList.Sort();
            arrayList.BinarySearch(77777);
            stopWatch.Stop();
            Console.WriteLine("ArrayList time - {0} ms", stopWatch.ElapsedMilliseconds);

            stopWatch.Reset(); stopWatch.Start();
            linkedList.Find(77777);
            stopWatch.Stop();
            Console.WriteLine("LinkedList time - {0} ms", stopWatch.ElapsedMilliseconds);

            Console.WriteLine("Operation Removal");
            stopWatch.Reset(); stopWatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                arrayList.Remove(i);
            }
            stopWatch.Stop();
            Console.WriteLine("ArrayList time - {0} ms", stopWatch.ElapsedMilliseconds);

            stopWatch.Reset(); stopWatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                linkedList.Remove(i);
            }
            stopWatch.Stop();
            Console.WriteLine("LinkedList time - {0} ms", stopWatch.ElapsedMilliseconds);
        }
    }
}
