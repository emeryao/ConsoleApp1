using ConsoleApp1.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    class AsyncHttpRequest : IEntrance
    {
        public void Run()
        {
            Task.Run(async () =>
            {
                using (HttpClient http = new HttpClient())
                {
                    string url = "http://www.google.cn/generate_204";

                    Console.WriteLine($"HTTP GET url: {url}");
                    HttpResponseMessage res = await http.GetAsync(url);
                    Console.WriteLine($"status code: {res.StatusCode} {(int)res.StatusCode}");
                }
            }).Wait();
        }
    }
}
