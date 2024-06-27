using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spotivy
{
    public class Song
    {
        String title;
        List<Artist> artists;
        String genre;
        Boolean isPlaying;
        Boolean paused;

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
            String songArtists = string.Empty;
            foreach (Artist artist in getArtists())
            {
                songArtists += artist.getName() + " ";
            }
            return songArtists;
        }

        public String playSong()
        {
            if (!isPlaying)
            {
                isPlaying = true;
                return "Currently playing: " + title + " by " + getArtistNames() + "\n";
            }
            return title + " is already playing\n";
        }

        public String pauseSong()
        {
            if (isPlaying)
            {
                isPlaying = false;
                paused = true;
                return "Paused: " + title + " by " + getArtistNames() + "\n";
            }
            return "There is no song playing\n";            
        }

        public String resumeSong()
        {
            if (paused)
            {
                paused = false;
                return playSong();
            }
            else if (paused == false && isPlaying)
            {
                return "The song is still playing\n";
            }
            else
            {
                return "There is no song playing\n";
            }
        }

        public String displayInfo()
        {
            return "Title: " + title + "\nArtists: " + getArtistNames() + "\nGenre: " + genre + "\n";
        }

        
    }
}
