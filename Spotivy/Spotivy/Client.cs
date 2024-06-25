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
        Boolean isLoggedIn;

        public Client(List<User> users, List<Artist> artists, List<Song> songs, List<Songlist> songlists)
        {
            this.users = users;
            this.artists = artists;
            this.songs = songs;
            this.songlists = songlists;
        }

        public void client()
        {
            logIn();
            if (isLoggedIn == true)
            {
                viewSongs();
            }

        }
        public Boolean logIn()
        {
            Console.WriteLine("Welcome to Spotivy!");
            Console.WriteLine("Who is listening?\n");
                      
                foreach (User user in users) {
                    Console.WriteLine(user.getName());
                }
                string chosenUser = Console.ReadLine();
                foreach (User user in users)
                {
                    if (user.name == chosenUser)
                    {
                        mainUser = user;
                        return isLoggedIn = true;
                    }
                }
            return isLoggedIn = false;
        }

        public void viewSongs()
        {
            foreach(Song song in songs)
            {
                Console.WriteLine(song.title);
            }
        }


    }
}
