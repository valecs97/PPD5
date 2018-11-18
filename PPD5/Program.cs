using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

namespace PPD5
{
    class Program
    {
        static void Main(string[] args)
        {
            First();
            Second();
            Third();
            Console.ReadKey();
        }

        static void First()
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            String[] addrs =
            {
                "www.google.com",
                "www.cs.ubbcluj.ro",
                "www.facebook.com",
                "www.yahoo.com",
                "www.gmail.com",
                "www.youtube.com",
                "www.9gag.com"
            };
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (String addr in addrs)
            {
                AsynchronousClient client = new AsynchronousClient(addr, 80);
                String response = client.StartClient();
                if (response != null)
                    Console.WriteLine("Response received from {0}", addr);
                else
                    Console.WriteLine("Response was not received from {0} !", addr);
            }
            stopwatch.Stop();
            long elapsed_time = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("Operation completed in {0} ms", elapsed_time);

            //Console.ReadKey();
            
        }

        static void Second()
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            String[] addrs =
            {
                "www.google.com",
                "www.cs.ubbcluj.ro",
                "www.facebook.com",
                "www.yahoo.com",
                "www.gmail.com",
                "www.youtube.com",
                "www.9gag.com"
            };
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Task<String>> tasks = new List<Task<String>>();
            foreach (String addr in addrs)
            {
                AsynchronousClient client = new AsynchronousClient(addr, 80);
                Task<String> task = Task<String>.Factory.StartNew(() => client.StartClient());
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            int i = 0;
            foreach (Task<String> t in tasks)
            {
                if (t.Result != null)
                    Console.WriteLine("Response received from {0}", addrs[i]);
                else
                    Console.WriteLine("Response was not received from {0} !", addrs[i]);
                i++;
            }
            stopwatch.Stop();
            long elapsed_time = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("Operation completed in {0} ms", elapsed_time);



            //Console.ReadKey();

        }

        static void Third()
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            String[] addrs =
            {
                "www.google.com",
                "www.cs.ubbcluj.ro",
                "www.facebook.com",
                "www.yahoo.com",
                "www.gmail.com",
                "www.youtube.com",
                "www.9gag.com"
            };
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Task<String>> tasks = new List<Task<String>>();
            foreach (String addr in addrs)
            {
                var task = DataAsync(addr);
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            int i = 0;
            foreach (Task<String> t in tasks)
            {
                if (t.Result != null)
                    Console.WriteLine("Response received from {0}", addrs[i]);
                else
                    Console.WriteLine("Response was not received from {0} !", addrs[i]);
                i++;
            }
            stopwatch.Stop();
            long elapsed_time = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("Operation completed in {0} ms", elapsed_time);
            
            

            //Console.ReadKey();

        }

        static async Task<String> DataAsync(String addr)
        {
            AsynchronousClient client = new AsynchronousClient(addr, 80);
            return await Task.Run(() =>client.StartClient());
        }
    }
}
