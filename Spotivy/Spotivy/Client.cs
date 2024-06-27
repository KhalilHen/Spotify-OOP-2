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
        Song currentSong;
        String songInfo;

        public Client(List<User> users, List<Artist> artists, List<Song> songs, List<Songlist> songlists)
        {
            this.users = users;
            this.artists = artists;
            this.songs = songs;
            this.songlists = songlists;
        }

        public void client1()
        {
            logIn();
            while (isLoggedIn == true)
            {
                Boolean playing = false;
                Boolean paused = false;
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
                            if (commandParts.Length >= 2)
                            {
                                String subCommand = commandParts[1].ToLower();
                                String songTitle = string.Join(" ", commandParts, 1, commandParts.Length - 1);
                                Boolean found = false;

                                foreach (Song song in songs)
                                {
                                    if (song.getTitle() == songTitle)
                                    {
                                        Console.WriteLine(song.playSong());
                                        currentSong = song;
                                        playing = true;
                                        found = true;
                                    }
                                }
                                if (!found)
                                {
                                    Console.WriteLine("This song does not exist\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid play command. Usage: play <title>\n");
                            }
                            break;

                        case "pause":
                            if (commandParts.Length == 1 && playing == true)
                            {
                                Console.WriteLine(currentSong.pauseSong());
                                playing = false;
                                paused = true;
                               
                            }
                            else if (commandParts.Length == 1 && playing == false)
                            {
                                Console.WriteLine("There is no song playing\n");
                            }
                            else
                            {
                                Console.WriteLine("Invalid pause command. Usage: pause\n");
                            }
                            break;

                        case "resume":
                            if (commandParts.Length == 1 && paused == true)
                            {
                                Console.WriteLine(currentSong.playSong());
                                playing = true;
                                paused = false;
                            }
                            else if (commandParts.Length == 1 && paused == false && playing == true)
                            {
                                Console.WriteLine("The song is still playing\n");
                            }
                            else if (commandParts.Length == 1 && playing == false)
                            {
                                Console.WriteLine("There is no song playing\n");
                            }
                            else
                            {
                                Console.WriteLine("Invalid resume command. Usage: resume\n");
                            }
                            break;

                        case "info":
                            if (commandParts.Length >= 2)
                            {
                               
                                String entityName = string.Join(" ", commandParts, 1, commandParts.Length - 1);
                                Boolean found = false;

                                foreach (Song song in songs)
                                {
                                    if (song.getTitle() == entityName)
                                    {
                                        Console.WriteLine(song.displayInfo());
                                        found = true;
                                    }
                                }
                                if (!found) {
                                    foreach (Songlist songlist in songlists)
                                    {
                                        if (songlist.getTitle() == entityName)
                                        {
                                            Console.WriteLine(songlist.displayInfo());
                                            found = true;
                                        }
                                    }
                                }
                                if (!found) {
                                    foreach (User user in users)
                                    {
                                        if (user.getName() == entityName)
                                        {
                                            Console.WriteLine(user.displayInfo());
                                            found = true;
                                        }
                                    }
                                }
                                if (!found)
                                {
                                    foreach (Artist artist in artists)
                                    {
                                        if (artist.getName() == entityName)
                                        {
                                            Console.WriteLine(artist.displayInfo());
                                            found = true;
                                        }
                                    }
                                }
                                if (!found)
                                {
                                    Console.WriteLine("This entity does not exist\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid info command. Usage: info <song>/<album>/<playlist>/<user>/<artist>\n");
                            }
                            break;


                        case "playlist":
                            if (commandParts.Length >= 3)
                            {
                                string subCommand = commandParts[1].ToLower();
                                string playlistName = string.Join(" ", commandParts, 2, commandParts.Length - 2);

                                switch (subCommand)
                                {
                                    case "view":
                                        Console.WriteLine("command not yet added");
                                        break;
                                    case "play":
                                        Console.WriteLine("command not yet added");
                                        break;
                                    case "create":
                                        Console.WriteLine("command not yet added");
                                        break;
                                    case "remove":
                                        Console.WriteLine("command not yet added");
                                        break;
                                    default:
                                        Console.WriteLine("Unknown playlist subcommand. Available subcommands: create");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid playlist command. Usage: playlist <subcommand> <name>");
                            }
                            break;
                        case "help":
                            Console.WriteLine("Available commands: play, list, help, exit");
                            break;
                        default:
                            Console.WriteLine("Unknown command. Type 'help' for a list of commands.");
                            break;
                    }
                }
            }
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
                        Console.WriteLine("3: Go back to the Main Menu");
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
                                                foreach (Song song in songlist.getSonglist())
                                                {
                                                    Console.WriteLine(songlist.playSonglist());
                                                    System.Threading.Thread.Sleep(5000);
                                                } 
                                                
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
                            case "3":
                                // code block
                                break;
                            default:
                                Console.WriteLine("\nInvalid input. Please enter a number from 1-3.");
                                break;
                        }
                        break;

                //user menu   
                case "3":
                    mainUser.userList(users, mainUser);
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
                Console.Write("> ");
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
