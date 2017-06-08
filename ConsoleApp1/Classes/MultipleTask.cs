using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    class MultipleTask : IEntrance
    {
        public void Run()
        {
            Task.Run(async () =>
            {
                // function to run in each task
                Func<long> func = () =>
                {
                    DateTime dt = DateTime.Now;
                    Console.WriteLine($"run in task {dt.ToString("HH:mm:ss.fffffff")} {Task.CurrentId}");
                    return dt.Ticks;
                };

                // get a task list of 10 tasks
                List<Task<long>> list = new List<Task<long>>();
                for (int i = 0; i < 10; i++)
                {
                    Task<long> t = new Task<long>(func);
                    list.Add(t);
                }

                // start every task
                list.ForEach(t => t.Start());

                // await for all tasks' result
                long[] results = await Task.WhenAll(list);

                // get some analysis
                Console.WriteLine($"earliest to latest: {(double)(results.Max() - results.Min()) / 100000}ms");
            }).Wait();
        }
    }
}
