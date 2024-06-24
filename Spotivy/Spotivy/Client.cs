using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Spotivy
{
    internal class Client
    {
        User mainUser;
        List<User> users;
        List<Artist> artists;
        List<Song> songs;
        List<Songlist> songlists;

        public Client(List<User> users, List<Artist> artists, List<Song> songs, List<Songlist> songlists)
        {
            this.users = users;
            this.artists = artists;
            this.songs = songs;
            this.songlists = songlists;
        }       
    }

        public void logIn()
        {
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
