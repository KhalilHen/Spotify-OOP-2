using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Spotivy
{
    public class Songlist
    {
        String title;
        List<Song> songs;

        public Songlist(String title, List<Song> songs)
        {
            this.title = title;
            this.songs = songs;
        }

        public String getTitle() { return title; }
        public List<Song> getSongs() {  return songs; }

        public String getSongsToString()
        {
             String songDetails = null;
             foreach (Song song in getSongs())
             {
                songDetails += song.getTitle() + " by " + song.getArtistNames() + "\n";
             }
             if (songDetails != null) { 
                return songDetails;
             }
             return "There are no songs available";
        }

        public String playSonglist()
        {
            String player = null;
            foreach (Song song in getSongs())
            {
                player += song.playSong() + "\n";
            }
            if (player != null)
            {
                return player;
            }
            return "There are no songs available";
        }
        
        public String displayInfo()
        {
            HashSet<String> genres = new HashSet<String>();
            HashSet<String> artists = new HashSet<String>();
            String genresString = string.Empty;
            String artistsString = string.Empty;
            foreach (Song song in songs)
            {                
                genres.Add(song.getGenre());
                foreach (Artist artist in song.getArtists()){
                    artists.Add(artist.getName());                  
                }
            }
            foreach (string genre in genres)
            {
                genresString += genre + " ";
            }
            foreach (string artist in artists)
            {
                artistsString += artist + " ";
            }
            return "Title: " + title + "\nGenres: " + genresString + "\nArtists: " + artistsString;
        }        
    }
}
