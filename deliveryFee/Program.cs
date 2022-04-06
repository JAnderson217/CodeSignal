/*To make sure that groceries can always be delivered, Instacart tries to equally distribute delivery requests throughout the day 
 * by including an additional delivery fee during busy periods. Each day is divided into several intervals that do not overlap and 
 * cover the whole day from 00:00 to 23:59. For each i the delivery fee in the intervals[i] equals fees[i]. Given the list of 
 * delivery requests deliveries, your task is to check whether the delivery fee is directly correlated to the order volume in each
 * interval i.e. the interval_fee / interval_deliveries value is constant for each interval throughout the day.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deliveryFee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("correlated test, should be True, False, True, False, False");
            Console.WriteLine(correlated(new int[] { 0, 10, 22 }, new int[] { 1, 3, 1 }, new int[,] {{8, 15 },
              { 12, 21 }, { 15, 48}, { 20, 17 }, { 23, 43} }));
            Console.WriteLine(correlated(new int[] { 0, 10, 22 }, new int[] { 1, 3, 1 }, new int[,] {{8, 15 },
              { 12, 21 }, { 15, 48}, { 20, 17 }}));
            Console.WriteLine(correlated(new int[] {0}, new int[] {34343}, new int[,] {{12, 34 },
              { 14, 45 }, { 17, 58}, { 23, 25 }}));
            Console.WriteLine(correlated(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
                20, 21, 22, 23 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21,
                    22, 23 }, new int[,] {{0,32}, {1,58}, {2,10}, {3,23}, {4,59}, {5,4}, {6,36}, {7,52}, {8,38}, {9,7}, 
                    {10,43}, {11,54}, {12,7}, {13,15}, {14,12}, {15,29}, {16,48}, {17,1}, {18,47}, {19,21}, {20,13}, {21,51}
                        , {22,7}, {23,20}}));
            Console.WriteLine(correlated(new int[] {0, 15}, new int[] { 100000, 99999 }, new int[,] {{1, 35 },
              { 15, 0 }}));
            Console.ReadLine();
        }

        public static bool correlated(int[] intervals, int[] fees, int[,]  deliveries){
            if (intervals.Length == 1) return true;
            int[] numDeliveries = new int[fees.Length];
            //count to track fee type, index for delivery number
            int count = 0;
            int index = 0;
            //while loop to check through all values, count number of deliveries in each fee type
            while (count < fees.Length && index < deliveries.Length/2) {
                bool next = false;
                if (count == fees.Length - 1 && deliveries[index, 0] >= intervals[count])
                {
                    numDeliveries[count]++;
                    index++;
                }
                else if (deliveries[index, 0] >= intervals[count] && deliveries[index, 0] < intervals[count + 1])
                {
                    numDeliveries[count]++;
                    index++;
                }
                else { 
                    next = true; 
                } 
                if (next) count++;
            }
            //compare expected vs actual deliveries
            for (int j = 0; j < fees.Length; j++) {
                if (fees[j] != numDeliveries[j]) return false;
            }
            return true;
        }
    }
}
