/* Given an integer n and an array a of length n, your task is to apply the following mutation to a:

Array a mutates into a new array b of length n.
For each i from 0 to n - 1, b[i] = a[i - 1] + a[i] + a[i + 1].
If some element in the sum a[i - 1] + a[i] + a[i + 1] does not exist, it should be set to 0. 
For example, b[0] should be equal to 0 + a[0] + a[1].*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"test should give [4,5,-1,2,1] {solution(5, new int[]{4,0,1,-2,3})}");
            Console.ReadLine();
        }
        public static int[] solution(int n, int[] a)
        {
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                if (n > 2)
                {
                    if (i == 0)
                    {
                        b[i] = 0 + a[i] + a[i + 1];
                    }
                    else if (i == a.Length - 1)
                    {
                        b[i] = a[i - 1] + a[i] + 0;
                    }
                    else
                    {
                        b[i] = a[i - 1] + a[i] + a[i + 1];
                    }
                }
                else
                {
                    if (n == 1)
                    {
                        return a;
                    }
                    else
                    {
                        b[0] = a[0];
                        b[1] = a[0] + a[1];
                    }
                }
            
            }
            foreach (int j in b)
            {
                Console.Write($"{j},");
            }
            return b;
        }
    }
}
