using ConsoleApp1.Interfaces;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1.Classes
{
    public class Sha1Hash : IEntrance
    {
        public static string Hash(string message)
        {
            byte[] hashBytes = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(message));
            return string.Join("", hashBytes.Select(b => b.ToString("x2")));
        }

        public void Run()
        {
            string message = "HelloWrold";
            Console.WriteLine($"SHA1 Hash of message: {message}");
            Console.WriteLine(Hash(message));
        }
    }
}
