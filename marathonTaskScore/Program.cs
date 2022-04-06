using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marathonTaskScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* In CodeSignal marathons, each task score is calculated independently. 
             * For a specific task, you get some amount of points if you solve it correctly, or you get a 0. 
             * Here is how the exact number of points is calculated:
               If you solve a task on your first attempt within the first minute, you get maxScore points.
               Each additional minute you spend on the task adds a penalty of (maxScore / 2) * (1 / marathonLength) to your final score.
               Each unsuccessful attempt adds a penalty of 10 to your final score.
               After all the penalties are deducted, if the score is less than maxScore / 2, you still get maxScore / 2 points. */
            Console.WriteLine($"marathon scores for length, maxScore, submissions, succesful submission times: 100,400,40,30" +
                $" and 100,400,95,30 gives scores of {score(100, 400, 4, 30)} and {score(100,400,95,30)}");
            Console.ReadLine();
        }
        public static int score(int marathonLength, int maxScore, int submissions, int successfulSubmissionTime)
        {
            int score = maxScore;
            if (successfulSubmissionTime == -1)
            {
                return 0;
            }
            if (submissions == 1 & successfulSubmissionTime <= 1)
            {
                return score;
            }
            int penalties = 0;
            if (submissions > 1)
            {
                penalties += ((submissions - 1) * 10);
            }
            float newInt = successfulSubmissionTime * maxScore / (2 * marathonLength);
            penalties += successfulSubmissionTime * maxScore / (2 * marathonLength);
            score -= penalties;
            if (score < (maxScore / 2))
            {
                return (maxScore / 2);
            }
            return score;
        }
    }
}
