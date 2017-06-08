using ConsoleApp1.Classes;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IEntrance entrance = new MultipleTask();
            entrance.Run();
        }
    }
}
