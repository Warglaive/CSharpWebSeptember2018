using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchDemo
{
    public static class Program
    {
        public static void Main()
        {
            var thread = new Thread(() =>
            {
                var result = NumberOfPrimesInInterval(2, 100000);
                Console.WriteLine(result + " Id: " + Thread.CurrentThread.ManagedThreadId);
            });
            thread.Start();


            var number = Task.Run(() => NumberOfPrimesInInterval(2, 100000));
            number.ContinueWith(task => Console.WriteLine(task.Result + " Id: " + Thread.CurrentThread.ManagedThreadId));
            //Console.WriteLine(NumberOfPrimesInInterval(2, 100000));
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "exit")
                {
                    return;
                }

                if (line != "exit")
                {
                    Console.WriteLine(line);
                }
            }
        }

        public static int NumberOfPrimesInInterval(int min, int max)
        {
            var count = 0;
            for (int i = min; i < max; i++)
            {
                var isPrimer = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrimer = false;
                        break;
                    }
                }

                if (isPrimer)
                {
                    count++;
                }
            }

            return count;
        }
    }
}