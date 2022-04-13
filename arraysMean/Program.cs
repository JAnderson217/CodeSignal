/*You are given an array of arrays a. Your task is to group the arrays a[i] by their mean values, 
 * so that arrays with equal mean values are in the same group, and arrays with different mean values 
 * are in different groups.

Each group should contain a set of indices (i, j, etc), such that the corresponding arrays (a[i], a[j], 
etc) all have the same mean. Return the set of groups as an array of arrays, where the indices within each
group are sorted in ascending order, and the groups are sorted in ascending order of their minimum element.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arraysMean
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] a = new int[][] { new int[] { 3, 3, 4, 2 }, new int[] { 4, 4 }, new int[] { 4, 0, 3, 3 }, 
                new int[] { 2, 3 }, new int[] { 3, 3, 3 }, new int[] { 11, 2, 5 }, new int[] { 2, 7, 3 }, 
                new int[] { 2, 7, 3 } , new int[] { 2, 7, 3, -2}};
            solution(a);
            Console.ReadLine();
        }
        public static int[][] solution(int[][] a)
        {
            //Create list with means of each array
            List<float> means = getMeans(a);
            //Get indexes of each array that shares mean
            int[][] meanIndex = countMeans(means);
            for (int i=0; i<meanIndex.Length; i++)
            {
                for (int j=0; j<meanIndex[i].Length; j++)
                {
                    Console.Write($"{meanIndex[i][j]},");
                }
                Console.WriteLine();
            }
            return meanIndex;
        }

        public static List<float> getMeans(int[][] a)
        {
            //returns means of each array to list
            List<float> means = new List<float>();
            float total = 0;
            float mean = 0;
            //loop through arrays, get mean, add to list
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    total = total + a[i][j];
                }
                mean = (float)total / (float)a[i].Length;
                Console.WriteLine($"total: {total} length: {a[i].Length} mean: {mean}");
                means.Add(mean);
                total = 0;
                mean = 0;
            }
            return means;
        }

        public static int[][] countMeans(List<float> means)
        {
            //Returns indexes of unique means
            //First populates a list with each unique mean
            List<float> uniqueMeans = new List<float>();
            for (int i=0; i<means.Count(); i++)
            {
                if (!uniqueMeans.Contains(means[i]))
                {
                    uniqueMeans.Add(means[i]);
                }
            }
            //array with length of number of unique means
            int[][] a = new int[uniqueMeans.Count][];
            //loop through to find count of each unique mean
            for (int i=0; i < uniqueMeans.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < means.Count; j++)
                {
                    if (uniqueMeans[i] == means[j]) {
                        count++;
                    }
                }
                a[i] = new int[count];
                count = 0;
            }
            //gets index for each unique mean, using LINQ   
            for (int i=0; i<uniqueMeans.Count; i++)
            {
                a[i] = means.Select((val, index) => new { val, index })
                    .Where(x => x.val == uniqueMeans[i])
                    .Select(x => x.index)
                    .ToArray();
            }
            return a;
        }

    }
}
