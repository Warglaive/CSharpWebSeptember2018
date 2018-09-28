using System;
using System.Threading;

namespace _01.EvenNumbersThread
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            
            var start = int.Parse(input[0]);
            var end = int.Parse(input[1]);

            var thread = new Thread(() => AllEvenNums(start, end));
            thread.Start();
            thread.Join();
            Console.WriteLine("Thread finished work");
        }

        private static void AllEvenNums(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}