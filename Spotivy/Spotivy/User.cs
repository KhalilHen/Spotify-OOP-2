using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Spotivy
{
    public class User
    {
        String name;
        List<User> friendlist;
        List<Playlist> playlists;

        public User(string name, List<User> friendlist, List<Playlist> playlists)
        {
            this.name = name;
            this.friendlist = friendlist;
            this.playlists = playlists;
        }

        public String getName() { return name; }
        public List<User> getFriends() {  return friendlist; }
        public List<Playlist> getPlaylists() { return playlists; }

        public void userList(List<User> users, User currentUser)
        {
            foreach (User user in users)
            {
                if (user  != currentUser)
                {
                    Console.WriteLine(user.getName());
                }
            }
        }

        public void createPlaylist(string playlistName)
        {
            List<Song> playlistSongs = new List<Song>();
            Playlist newPlaylist = new Playlist(playlistName, playlistSongs);
            playlists.Add(newPlaylist);
        }

        public void removePlaylist(string playlistName)
        {
            Playlist toRemove = null;
            foreach (Playlist playlist in playlists)
            {
                if (playlist.getTitle() == playlistName)
                {
                    toRemove = playlist;                 
                }
            }
            if (toRemove != null) {
            playlists.Remove(toRemove);
            }
        }


        public String getPlaylistsToString()
        {
            String playlistTitles = string.Empty;
            foreach (Playlist playlist in playlists)
            {
                playlistTitles += playlist.getTitle() + "\n";
            }
            return playlistTitles;
        }
    }
}
