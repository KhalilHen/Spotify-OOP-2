using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spotivy
{
    public class Song
    {
        public String title;
        List<Artist> artists;
        String genre;

        public Song(String title, List<Artist> artists, String genre)
        {
            this.title = title;
            this.artists = artists;
            this.genre = genre;
        }
    }
}
