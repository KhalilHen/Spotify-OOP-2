using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
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
        List<Songlist> albums;
        List<Playlist> playlists;
        Song currentSong;


        public Client(List<User> users, List<Artist> artists, List<Song> songs, List<Songlist> albums, List<Playlist> playlists)
        {
            this.users = users;
            this.artists = artists;
            this.songs = songs;
            this.albums = albums;
            this.playlists = playlists;
        }
       
        public String play(String[] commandParts)
        {
           
            if (commandParts.Length >= 2)
            {
                String songTitle = string.Join(" ", commandParts, 1, commandParts.Length - 1);               

                foreach (Song song in songs)
                {
                    if (song.getTitle() == songTitle)
                    {
                        currentSong = song;
                        return song.playSong();
                    }
                }
                return "This song does not exist\n";               
            }
            else
            {
                return "Invalid play command. Usage: play <title>\n";
            }
        }

        public String pause(String[] commandParts)
        {
            if (commandParts.Length == 1 && currentSong != null)
            {
                return currentSong.pauseSong();
            }
            else if (commandParts.Length == 1 && currentSong == null)
            {
                return "There is no song playing\n";
            }
            else
            {
                return "Invalid pause command. Usage: pause\n";
            }
        }

        public String resume(String[] commandParts)
        {
            if (commandParts.Length == 1 && currentSong != null)
            {
                return currentSong.resumeSong();
            }
            else if (commandParts.Length == 1 && currentSong == null)
            {
                return "No song has been selected";
            }
            else
            {
                return "Invalid resume command. Usage: resume\n";
            }

        }

        public String info(String[] commandParts)
        {
            if (commandParts.Length >= 2)
            {
                String entityName = string.Join(" ", commandParts, 1, commandParts.Length - 1);

                foreach (Song song in songs)
                {
                    if (song.getTitle() == entityName)
                    {
                        return song.displayInfo();
                    }
                }
                foreach (Songlist songlist in albums)
                {
                    if (songlist.getTitle() == entityName)
                    {
                        return songlist.displayInfo();
                    }
                }
                foreach (Playlist playlist in playlists)
                {
                    if (playlist.getTitle() == entityName)
                    {
                        return playlist.displayInfo();
                    }
                }
                foreach (User user in users)
                {
                    if (user.getName() == entityName)
                    {
                        /*TO DO
                         * Console.WriteLine(user.displayInfo());*/
                           
                    }
                }
                foreach (Artist artist in artists)
                {
                    if (artist.getName() == entityName)
                    {
                        /*TO DO 
                         * Console.WriteLine(artist.displayInfo());*/
                            
                    }
                }           
                return "This entity does not exist\n";                
            }
            else
            {
                return "Invalid info command. Usage: info <song>/<album>/<playlist>/<user>/<artist>\n";
            }
        }

        public String album(String[] commandParts)
        {
            if (commandParts.Length >= 3)
            {
                string subCommand = commandParts[1].ToLower();
                string albumName = string.Join(" ", commandParts, 2, commandParts.Length - 2);

                switch (subCommand)
                {

                    case "view":
                        return viewAlbum(albumName);
                    case "play":
                        return playAlbum(albumName);
                    default:
                        return "Invalid album subcommand. Available subcommands: view, play";
                }
            }
            else
            {
                return "Invalid playlist command. Usage: album <subcommand> <name>";
            }
        }

        internal String viewAlbum(String albumName)
        {            
                foreach (Songlist album in albums)
                {
                    if (album.getTitle() == albumName)
                    {
                        return album.getSongsToString();
                    }
                }            
            return "Album does not exist";
        }

        internal String playAlbum(String albumName)
        {

            foreach (Songlist album in albums)
            {
                if (album.getTitle() == albumName)
                {
                    return album.playSonglist();
                }
            }
            return "Album does not exist";
        }

        public String playlist(String[] commandParts)
        {
            if (commandParts.Length >= 3)
            {
                string subCommand = commandParts[1].ToLower();
                string playlistName = string.Join(" ", commandParts, 2, commandParts.Length - 2);

                switch (subCommand)
                {

                    case "view":
                        return viewPlaylist(playlistName);
                    case "play":
                        return playPlaylist(playlistName);
                    case "create":
                        playlists.Add(mainUser.createPlaylist(playlistName));
                        return "Playlist created";
                    case "remove":
                        if (mainUser.removePlaylist(playlistName) != null)
                        {                                                   
                        playlists.Remove(mainUser.removePlaylist(playlistName));
                        return "Playlist removed";
                        }
                        return "Playlist does not exist";
                    default:
                        return "Invalid playlist subcommand. Available subcommands: view, play, create, remove";                        
                }
            }
            else
            {
                return "Invalid playlist command. Usage: playlist <subcommand> <name>";
            }
        }

        internal String viewPlaylist(String playlistName)
        {
            if (playlistName == "all")
            {
                return mainUser.getPlaylistsToString();
            }
            else
            {
                foreach (Playlist playlist in playlists)
                {
                    if (playlist.getTitle() == playlistName)
                    {
                        return playlist.getSongsToString();
                    }
                }
            }
            return "Playlist does not exist";
        }

        internal String playPlaylist(String playlistName)
        {
            
            foreach (Playlist playlist in playlists)
            {
                if (playlist.getTitle() == playlistName)
                {
                    return playlist.playSonglist();
                }
            }
            return "Playlist does not exist";
        }

        public String userList(String[] commandParts)
        {

            return mainUser.userList(users, mainUser);
        }

        public Boolean logIn()
        {
            Console.WriteLine("Welcome to Spotivy!");
            Console.WriteLine("Who is listening?\n");
                      
                foreach (User user in users) {
                    Console.WriteLine(user.getName());
                }
                Console.Write("> ");
                String chosenUser = Console.ReadLine();
                foreach (User user in users)
                {
                    if (user.getName() == chosenUser)
                    {
                        mainUser = user;
                        return true;
                    }
                }
            return false;
        }

        public String getAllSongsToString()
        {
            String songInfo = string.Empty;
            Console.WriteLine("");
            foreach (Song song in songs)
            {
                songInfo += song.getTitle() + " by " + song.getArtistNames() + "\n";     
            }
            return songInfo;
        }
    }
}
