using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        internal String playSonglist()
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

       

    }
}
