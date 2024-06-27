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
            List<Song> playlistSongs1 = new List<Song>();
            List<Song> playlistSongs2 = new List<Song>();
            Artist artist1 = new Artist("Artiest1", albumList1, artistSingles1);
            
            List<Artist> artistList1 = new List<Artist>();
            artistList1.Add(artist1);
            

            Song song1 = new Song("Titel1", artistList1, "Pop");
            Song song2 = new Song("Titel2", artistList1, "Pop");
            Song song3 = new Song("Titel3", artistList1, "Rock");
            Song song4 = new Song("Titel4", artistList1, "Pop");
            Song song5 = new Song("Titel5", artistList1, "Rock");
            Song song6 = new Song("Titel6", artistList1, "Pop");
            PlayList playlist1 = new PlayList("Playlist1", playlistSongs1);
            PlayList playlist2 = new PlayList("Playlist2", playlistSongs2);
                      
            List<User> allUsers = new List<User>();
            List<Artist> allArtists = new List<Artist>();
            List<Song> allSongs = new List<Song>();
            List<Songlist> allSonglists = new List<Songlist>();


            // add songs to playlist
            playlistSongs1.Add(song1);
            playlistSongs1.Add(song2);
            playlistSongs1.Add(song3);
            playlistSongs2.Add(song4);
            playlistSongs2.Add(song5);
            playlistSongs2.Add(song6);
            // add playlists to all playlists of a single user
            playlistList1.Add(playlist1);
            playlistList1.Add(playlist2);

            allUsers.Add(user1);
            allUsers.Add(user2);
            allUsers.Add(user3);
            allArtists.Add(artist1);
            artistSingles1.Add(song1);
            artistSingles1.Add(song2);
            artistSingles1.Add(song3);
            artistSingles1.Add(song4);
            artistSingles1.Add(song5);
            artistSingles1.Add(song6);
            allSongs.Add(song1);
            allSongs.Add(song2);
            allSongs.Add(song3);
            allSongs.Add(song4);
            allSongs.Add(song5);
            allSongs.Add(song6);
            allSonglists.Add(playlist1);
            allSonglists.Add(playlist2);

            Client client = new Client(allUsers, allArtists, allSongs, allSonglists);

            client.client();
            

        }
    }
}