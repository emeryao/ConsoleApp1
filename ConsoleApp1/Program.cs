using ConsoleApp1.Classes;
using ConsoleApp1.Interfaces;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IEntrance entrance = new AesEncryption();
            Console.WriteLine($"Start running class: {entrance.GetType().Name}\n");
            entrance.Run();
        }
    }
}
