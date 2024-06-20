using System;
using System.Collections.Generic;
using System.Linq;
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
        public Client(List<User> users, List<Artist> artists, List<Song> songs, List<Songlist> songlists)
        {
            this.users = users;
            this.artists = artists;
            this.songs = songs;
            this.songlists = songlists;
        }

       
    }

    
}
