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
    public class HashTableAndDictionary
    {
        public static void ComparisonofHashTableAndDictionary()
        {
            Stopwatch stopWatch = new Stopwatch();
            Hashtable hashtable = new Hashtable();
            Dictionary<object, object> dictionary = new Dictionary<object, object>();

            Console.WriteLine("Operation add 1000000 items");
            stopWatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                hashtable.Add(i,i);
            }
            stopWatch.Stop();
            Console.WriteLine("Hashtable time - {0} ms", stopWatch.ElapsedMilliseconds);

            stopWatch.Reset(); stopWatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                dictionary.Add(i, i);
            }
            stopWatch.Stop();
            Console.WriteLine("Dictionary time - {0} ms", stopWatch.ElapsedMilliseconds);

            Console.WriteLine("Operation Search");
            stopWatch.Reset(); stopWatch.Start();
            hashtable.Contains(77777);
            stopWatch.Stop();
            Console.WriteLine("Hashtable time - {0} ms", stopWatch.ElapsedMilliseconds);

            stopWatch.Reset(); stopWatch.Start();
            dictionary.ContainsKey(77777);
            stopWatch.Stop();
            Console.WriteLine("Dictionary time - {0} ms", stopWatch.ElapsedMilliseconds);

            Console.WriteLine("Operation Removal");
            stopWatch.Reset(); stopWatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                hashtable.Remove(i);
            }
            stopWatch.Stop();
            Console.WriteLine("Hashtable time - {0} ms", stopWatch.ElapsedMilliseconds);

            stopWatch.Reset(); stopWatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                dictionary.Remove(i);
            }
            stopWatch.Stop();
            Console.WriteLine("Dictionary time - {0} ms", stopWatch.ElapsedMilliseconds);
        }
    }
}
