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
    public class StackAndQueue
    {
        public static void ComparisonofStackAndQueue()
        {
            Stopwatch stopWatch = new Stopwatch();
            Stack stack = new Stack();
            Queue queue = new Queue();

            Console.WriteLine("Operation add 1000000 items");
            stopWatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                stack.Push(i);
            }
            stopWatch.Stop();
            Console.WriteLine("Stack time - {0} ms", stopWatch.ElapsedMilliseconds);

            stopWatch.Reset(); stopWatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                queue.Enqueue(i);
            }
            stopWatch.Stop();
            Console.WriteLine("Queue time - {0} ms", stopWatch.ElapsedMilliseconds);

            Console.WriteLine("Operation Search");
            stopWatch.Reset(); stopWatch.Start();
            stack.Contains(77777);
            stopWatch.Stop();
            Console.WriteLine("Stack time - {0} ms", stopWatch.ElapsedMilliseconds);

            stopWatch.Reset(); stopWatch.Start();
            queue.Contains(77777);
            stopWatch.Stop();
            Console.WriteLine("Queue time - {0} ms", stopWatch.ElapsedMilliseconds);

            Console.WriteLine("Operation Removal");
            stopWatch.Reset(); stopWatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                stack.Pop();
            }
            stopWatch.Stop();
            Console.WriteLine("Stack time - {0} ms", stopWatch.ElapsedMilliseconds);

            stopWatch.Reset(); stopWatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                queue.Dequeue();
            }
            stopWatch.Stop();
            Console.WriteLine("Queue time - {0} ms", stopWatch.ElapsedMilliseconds);
        }
    }
}
