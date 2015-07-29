using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Library
{
    public class Calculator
    {
        public static IEnumerable<int> GetFibonacciNumbers(int count)
        {
            int prev = 0;
            int result = 1;
            yield return result;
            for (int i = 0; i < count - 1; i++)
            {
                int temp = prev;
                prev = result;
                result = temp + result;
                yield return result;
            }
        }
    }
}
