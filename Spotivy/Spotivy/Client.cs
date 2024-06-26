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
        Boolean isLoggedIn;
        String songInfo;

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
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1: Play song");
                Console.WriteLine("2: View playlists");
                Console.WriteLine("3: Find users");
                Console.WriteLine("4: Find artists");
                Console.WriteLine("5: Log out");
                String userInput = Console.ReadLine();
                switch (userInput)
                {
                    //song menu
                    case "1":
                        Console.WriteLine("\nChoose a song to play.");
                        Console.WriteLine(getAllSongs());
                        String chosenSong = Console.ReadLine();
                        foreach (Song song in songs)
                        {
                            if (song.getTitle() == chosenSong)
                            {
                                Console.WriteLine(song.playSong());
                                Console.WriteLine("\nWhat would you like to do?");
                                Console.WriteLine("1: Pause song");
                                Console.WriteLine("2: Skip song");
                                Console.WriteLine("3: Display song details");
                                Console.WriteLine("4: Add to playlist");
                                Console.WriteLine("5: Go back to the Main Menu");
                                userInput = Console.ReadLine();
                                switch (userInput)
                                {
                                    case "1":
                                        Console.WriteLine(song.pauseSong());
                                        break;
                                    case "2":
                                        // code block
                                        break;
                                    case "3":
                                        Console.WriteLine(song.displayInfo());
                                        break;
                                    case "4":
                                        // code block
                                        break;
                                    case "5":
                                        // code block
                                        break;
                                    default:
                                        Console.WriteLine("\nInvalid input. Please enter a number from 1-4.");
                                        break;
                                }
                            }
                        }
                        break;

                    //playlist menu
                    case "2":
                        Console.WriteLine("\n" + mainUser.getSonglistListToString());
                        Console.WriteLine("What would you like to do?");
                        Console.WriteLine("1: Select a playlist");
                        Console.WriteLine("2: Create a new playlist");
                        userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                Console.WriteLine("\nChoose a playlist.");
                                String chosenPlaylist = Console.ReadLine();
                                foreach (Songlist songlist in mainUser.getSonglistList())
                                {
                                    if (songlist.getTitle() == chosenPlaylist)
                                    {
                                        Console.WriteLine("\nWhat would you like to do?");
                                        Console.WriteLine("1: Play playlist");
                                        Console.WriteLine("2: View playlist");
                                        Console.WriteLine("3: Remove playlist");
                                        Console.WriteLine("4: Go back to the Main Menu");
                                        userInput = Console.ReadLine();
                                        switch (userInput)
                                        {
                                            case "1":
                                                
                                                break;
                                            case "2":
                                                Console.WriteLine("\n" + songlist.getSonglistToString()); 
                                                break;
                                            case "3":
                                              
                                                break;
                                            case "4":
                                                // code block
                                                break;
                                            default:
                                                Console.WriteLine("\nInvalid input. Please enter a number from 1-4.");
                                                break;
                                        }
                                    }
                                }
                                break;
                            case "2":
                                // code block
                                break;
                            default:
                                Console.WriteLine("\nInvalid input. Please enter a number from 1-4.");
                                break;
                        }
                        break;

                    case "3":
                        // code block
                        break;
                    case "4":
                        // code block
                        break;
                    case "5":
                        // code block
                        break;
                    default:
                        Console.WriteLine("\nInvalid input. Please enter a number from 1-5.");
                        break;
                }
            }
        }
        public Boolean logIn()
        {
            Console.WriteLine("Welcome to Spotivy!");
            Console.WriteLine("Who is listening?\n");
                      
                foreach (User user in users) {
                    Console.WriteLine(user.getName());
                }
                String chosenUser = Console.ReadLine();
                foreach (User user in users)
                {
                    if (user.getName() == chosenUser)
                    {
                        mainUser = user;
                        return isLoggedIn = true;
                    }
                }
            return isLoggedIn = false;
        }

        public String getAllSongs()
        {
            Console.WriteLine("");
            foreach (Song song in songs)
            {
                songInfo += song.getTitle() + " by " + song.getArtistNames() + "\n";     
            }
            return songInfo;
        }

    }
}
