using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Spotivy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User();
            User user2 = new User();
            User user3 = new User();
            Artist artist1 = new Artist();
            Artist artist2 = new Artist();
            Artist artist3 = new Artist();
            Song song1 = new Song();
            Song song2 = new Song();
            Song song3 = new Song();
            Song song4 = new Song();
            Song song5 = new Song();
            Song song6 = new Song();
            Songlist songlist1 = new Songlist();
            Songlist songlist2 = new Songlist();
            

            List<User> users = new List<User>();
            List<Artist> artists = new List<Artist>();
            List<Song> songs = new List<Song>();
            List<Songlist> songlists = new List<Songlist>();

            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            artists.Add(artist1);
            artists.Add(artist2);
            artists.Add(artist3);
            songs.Add(song1);
            songs.Add(song2);
            songs.Add(song3);
            songs.Add(song4);
            songs.Add(song5);
            songs.Add(song6);
            songlists.Add(songlist1);
            songlists.Add(songlist2);

            Client client = new Client(users, artists, songs, songlists);



            Console.WriteLine("Welcome to Spotivy!");
            Console.WriteLine("Who is listening?");

        }
    }
}