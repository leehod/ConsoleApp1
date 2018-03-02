using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        public static void Main()
        {
            Console.WriteLine("1: Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Before wait");
            Task t = FooAsync();
            Console.WriteLine("4: Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("After FooAsync");
            t.Wait();
            Console.WriteLine("5: Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Done");
        }

        private static async Task FooAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine("2: Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Done with first delay");
            await Task.Delay(100);
            Console.WriteLine("3: Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Done with second delay");
        }
    }
}
