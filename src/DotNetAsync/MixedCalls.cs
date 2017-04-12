using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetAsync
{
    class MixedCalls
    {
        public static void Run()
        {
            var asyncMethod = RunMethodAsync();

            RunMethodSync();

            asyncMethod.Wait();
        }

        private static void RunMethodSync()
        {
            Console.WriteLine("Running SYNC method.");
        }

        private static async Task RunMethodAsync()
        {
            await Task.Delay(500);
            await Console.Out.WriteLineAsync("Running ASYNC method 1.");
            await Task.Run(() => Console.WriteLine("Running ASYNC method 2."));
        }
        
    }
}