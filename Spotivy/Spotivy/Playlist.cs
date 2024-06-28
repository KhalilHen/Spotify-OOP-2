using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotivy
{
    public class Playlist : Songlist
    {
        public Playlist(String title, List<Song> songs) : base(title, songs)
        {
        }
    }
}
