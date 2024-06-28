using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotivy
{
    public class Artist
    {
        String name;
        List<Songlist> albums;
        List<Song> singles;

        public Artist(String name, List<Songlist> albums, List<Song> singles)
        {
            this.name = name;
            this.albums = albums;
            this.singles = singles;
        }








        public String getName() { return name; }
        public List<Song> getSingles() { return singles; }
        public List<Songlist> getAlbums() { return albums; }


        public static void artistList(List<Artist> artists)
        {
            foreach (Artist artist in artists)

            {
                Console.WriteLine(artist.getName());

            }
        }
    }
}
