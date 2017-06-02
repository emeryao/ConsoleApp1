using ConsoleApp1.Interfaces;
using System;

namespace ConsoleApp1.Classes
{
    public class HelloWorld : IEntrance
    {
        public void Run() => Console.WriteLine("Hello World");
    }
}
