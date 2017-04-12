using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DotNetAsync
{
    class HTTPCalls
    {
        public static void Run()
        {
            var stopWatch = new Stopwatch();

            Console.WriteLine("Sync API Start:");
            stopWatch.Start();
            RunSyncTests();
            stopWatch.Stop();
            Console.WriteLine($"Sync Ellapsed Seconds: {stopWatch.Elapsed.TotalSeconds}");

            stopWatch.Reset();

            Console.WriteLine("Async API Start:");
            stopWatch.Start();
            RunAsyncTests();
            stopWatch.Stop();
            Console.WriteLine($"Async Ellapsed Seconds: {stopWatch.Elapsed.TotalSeconds}");

            Console.ReadKey();
        }

        private static void RunSyncTests()
        {
            var httpCaller = new HTTPCaller(@"http://jsonplaceholder.typicode.com");

            httpCaller.CallApiStringAsync("/posts").Wait();
            httpCaller.CallApiStringAsync("/photos").Wait();
            httpCaller.CallApiStringAsync("/comments").Wait();
            httpCaller.CallApiStringAsync("/todos").Wait();
        }

        private static void RunAsyncTests()
        {
            var httpCaller = new HTTPCaller(@"http://jsonplaceholder.typicode.com");

            var apiCall1 = httpCaller.CallApiStringAsync("/posts");
            var apiCall2 = httpCaller.CallApiStringAsync("/photos");
            var apiCall3 = httpCaller.CallApiStringAsync("/comments");
            var apiCall4 = httpCaller.CallApiStringAsync("/todos");

            Task.WaitAll(apiCall1, apiCall2, apiCall3, apiCall4);            
        }

    }
    

}