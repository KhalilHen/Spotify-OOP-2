using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace Spotivy
{
    internal class Program
    {
        static void Main(string[] args)
        {
          

            List<Playlist> playlists1 = new List<Playlist>();
            List<Playlist> playlists2 = new List<Playlist>();
            List<Playlist> playlists3 = new List<Playlist>();
            List<Playlist> allPlaylists = new List<Playlist>();
            List<User> friendlist1 = new List<User>();
            List<User> friendlist2 = new List<User>();
            List<User> friendlist3 = new List<User>();
            User user1 = new User("Bo", friendlist1, playlists1);
            User user2 = new User("Khalil", friendlist2, playlists2);
            User user3 = new User("Robert", friendlist3, playlists3);

            /*Artist 1*/
            List<Songlist> albums1 = new List<Songlist>();
            List<Song> singles1 = new List<Song>();
            Artist artist1 = new Artist("Artiest1", albums1, singles1);
            List<Artist> featuredArtists = new List<Artist>();
            featuredArtists.Add(artist1);
            Song song1 = new Song("Titel1", featuredArtists, "Pop");
            Song song2 = new Song("Titel2", featuredArtists, "Pop");
            Song song3 = new Song("Titel3", featuredArtists, "Rock");
            Song song4 = new Song("Titel4", featuredArtists, "Pop");
            Song song5 = new Song("Titel5", featuredArtists, "Rock");
            Song song6 = new Song("Titel6", featuredArtists, "Pop");
            singles1.Add(song1);
            singles1.Add(song2);
            singles1.Add(song3);
            singles1.Add(song4);
            singles1.Add(song5);
            singles1.Add(song6);






            List<Song> playlistSongs1 = new List<Song>();
            List<Song> playlistSongs2 = new List<Song>();

           
            
            

          
            Playlist playlist1 = new Playlist("Playlist1", playlistSongs1);
            Playlist playlist2 = new Playlist("Playlist2", playlistSongs2);
                      
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
            playlists1.Add(playlist1);
            playlists1.Add(playlist2);

            allUsers.Add(user1);
            allUsers.Add(user2);
            allUsers.Add(user3);
            allArtists.Add(artist1);
            allPlaylists.Add(playlist1);
            allPlaylists.Add(playlist2);

            allSongs.Add(song1);
            allSongs.Add(song2);
            allSongs.Add(song3);
            allSongs.Add(song4);
            allSongs.Add(song5);
            allSongs.Add(song6);
            allSonglists.Add(playlist1);
            allSonglists.Add(playlist2);

            Client client = new Client(allUsers, allArtists, allSongs, allSonglists, allPlaylists);

            

            run();

            void run()
            {
                while (client.logIn() == true)
                {
                    Console.WriteLine("Logged in succesfully.\n");
                    while (true)
                    {
                        Console.Write("> ");
                        String input = Console.ReadLine();
                        String[] commandParts = input.Split(' ');

                        if (commandParts.Length == 0) continue;

                        String command = commandParts[0].ToLower();

                        switch (command)
                        {
                            case "play":
                                Console.WriteLine(client.play(commandParts));
                                break;
                            case "pause":
                                Console.WriteLine(client.pause(commandParts));
                                break;
                            case "resume":
                                Console.WriteLine(client.resume(commandParts));
                                break;
                            case "info":
                                Console.WriteLine(client.info(commandParts));
                                break;
                            case "playlist":
                                Console.WriteLine(client.playlist(commandParts));
                                break;
                            case "users":
                                Console.WriteLine(client.users(commandParts));
                                break;
                            case "help":
                                Console.WriteLine("Available commands: play, pause, resume, info, playlist, help\n");
                                Console.WriteLine(">play <title>: Plays a specific song");
                                Console.WriteLine(">pause: Pauses the song that's currently playing");
                                Console.WriteLine(">resume: Resumes the paused song");
                                Console.WriteLine(">info <song>/<album>/<playlist>/<artist>/<user>: Display more information on a song, album, playlist, artist or user");
                                Console.WriteLine(">playlist play <title>: Plays playlist that matches selected title");
                                Console.WriteLine(">playlist view <title>/all: Views all songs in selected playlist, or shows all playlists belonging to that user");
                                Console.WriteLine(">playlist create <title>: Creates a new playlist with the selected title");
                                Console.WriteLine(">playlist remove <title>: Removes playlist that matches selected title");
                                Console.WriteLine(">users: View all users on the application");
                                Console.WriteLine(">help: List of commands");
                                break;
                            default:
                                Console.WriteLine("Unknown command. Type 'help' for a list of commands.");
                                break;
                        }
                    }
                }
            }        
        }
    }
}