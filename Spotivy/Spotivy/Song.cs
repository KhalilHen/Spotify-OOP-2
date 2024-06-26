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
        String title;
        List<Artist> artists;
        String genre;
        String songArtists;

        public Song(String title, List<Artist> artists, String genre)
        {
            this.title = title;
            this.artists = artists;
            this.genre = genre;
        }

        public String getTitle() { return title; }
        public List<Artist> getArtists() {  return artists; }
        public String getGenre() {  return genre; }

        public String getArtistNames()
        {
            songArtists = string.Empty;
            foreach (Artist artist in getArtists())
            {
                songArtists += artist.getName() + " ";
            }
            return songArtists;
        }

        public void playSong()
        {
            Console.WriteLine("\nCurrently playing: " + getTitle() + " by " + getArtistNames());
        }
    }
}
