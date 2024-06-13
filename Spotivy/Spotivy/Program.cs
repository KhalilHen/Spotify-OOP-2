using System;

namespace Spotivy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Bo", "1234");
            User user2 = new User("Khalil", "5678");
            User user3 = new User("Robert", "9012");

            Console.WriteLine("Welcome to Spotivy!");
            Console.WriteLine("\nWho is listening?");


            ConsoleKeyInfo key;

            while (true)
            {
            Console.WriteLine("\u001b[32m" + user1.getName() + "\u001b[0m");
            Console.WriteLine(user2.getName());
            Console.WriteLine(user3.getName());

                key = Console.ReadKey(true);
            }
        }
    }
}