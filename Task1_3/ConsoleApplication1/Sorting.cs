using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Sorting
    {
        public static void BubbleSort(List<string> strings)
        {
            bool flag = true;
            string temp;
            int numLength = strings.Count;
            //sorting an array
            for (int i = 1; (i <= (numLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (numLength - 1); j++)
                {
                    if (strings[j + 1].Length > strings[j].Length)
                    {
                        temp = strings[j];
                        strings[j] = strings[j + 1];
                        strings[j + 1] = temp;
                        flag = true;
                    }
                }
            }
         }
    }
}
