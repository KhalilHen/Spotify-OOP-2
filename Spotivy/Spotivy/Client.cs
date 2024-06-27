using System;
using System.Collections.Generic;
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
        List<Songlist> songlists;
        Song currentSong;


        public Client(List<User> users, List<Artist> artists, List<Song> songs, List<Songlist> songlists)
        {
            this.users = users;
            this.artists = artists;
            this.songs = songs;
            this.songlists = songlists;
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
                foreach (Songlist songlist in songlists)
                {
                    if (songlist.getTitle() == entityName)
                    {
                       /* TO DO 
                        * Console.WriteLine(songlist.displayInfo());*/
                           
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

        public String getAllSongs()
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
