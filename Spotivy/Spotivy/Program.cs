using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Spotivy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Songlist> playlistList1 = new List<Songlist>();
            List<Songlist> playlistList2 = new List<Songlist>();
            List<Songlist> playlistList3 = new List<Songlist>();
            List<Songlist> albumList1 = new List<Songlist>();
            List<User> friendlist1 = new List<User>();
            List<User> friendlist2 = new List<User>();
            List<User> friendlist3 = new List<User>();
            User user1 = new User("Bo", playlistList1, friendlist1);
            User user2 = new User("Khalil", playlistList2, friendlist2);
            User user3 = new User("Robert", playlistList3, friendlist3);
            List<Song> artistSingles1 = new List<Song>();
            List<Song> playlist1 = new List<Song>();
            List<Song> playlist2 = new List<Song>();
            Artist artist1 = new Artist("Artiest1", albumList1, artistSingles1);
            
            List<Artist> artistList1 = new List<Artist>();
            artistList1.Add(artist1);
            Song song1 = new Song("Titel1", artistList1, "Pop");
            Song song2 = new Song("Titel2", artistList1, "Pop");
            Song song3 = new Song("Titel3", artistList1, "Rock");
            Song song4 = new Song("Titel4", artistList1, "Pop");
            Song song5 = new Song("Titel5", artistList1, "Rock");
            Song song6 = new Song("Titel6", artistList1, "Pop");
            Songlist songlist1 = new Songlist("Playlist 1", playlist1);
            Songlist songlist2 = new Songlist("Playlist 2", playlist2);
            
            List<User> users = new List<User>();
            List<Artist> artists = new List<Artist>();
            List<Song> songs = new List<Song>();
            List<Songlist> songlists = new List<Songlist>();

            // add playlists to list of playlists per user
            playlistList1.Add(songlist1);
            playlistList1.Add(songlist2);

            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            artists.Add(artist1);
            /*artists.Add(artist2);
            artists.Add(artist3);*/
            artistSingles1.Add(song1);
            artistSingles1.Add(song2);
            artistSingles1.Add(song3);
            artistSingles1.Add(song4);
            artistSingles1.Add(song5);
            artistSingles1.Add(song6);
            songs.Add(song1);
            songs.Add(song2);
            songs.Add(song3);
            songs.Add(song4);
            songs.Add(song5);
            songs.Add(song6);
            songlists.Add(songlist1);
            songlists.Add(songlist2);

            Client client = new Client(users, artists, songs, songlists);

            client.client();
            

        }
    }
}