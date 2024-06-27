using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Spotivy
{
    public class User : Person
    {
        List<User> friendlist;

        public User(string name, List<Songlist> songlistList, List<User> friendlist) : base(name, songlistList)
        {
            this.friendlist = friendlist;
        }
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
            List<Song> songs = new List<Song>();
            Songlist songlist = new Songlist(playlistName, songs);
            getSonglistList().Add(songlist);
        }

        public void removePlaylist(string playlistName)
        {
            Songlist toRemove = null;
            foreach (Songlist songlist in getSonglistList())
            {
                if (songlist.getTitle() == playlistName)
                {
                    toRemove = songlist;                 
                }
            }
            if (toRemove != null) {
            getSonglistList().Remove(toRemove);
            }
        }
    }
}
