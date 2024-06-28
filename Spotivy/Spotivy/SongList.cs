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
        private int currentSongIndex;

        public Songlist(String title, List<Song> songs)
        {
            this.title = title;
            this.songs = songs;
            currentSongIndex = 0;
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
             return "Playlist does not yet contain any songs";
        }

       /* public String playSonglist()
        {
            if (currentSongIndex < songs.Count)
            {
                Song currentSong = songs[currentSongIndex];
                currentSongIndex++;
                return currentSong.playSong();
            }
            else
            {
                currentSongIndex = 0;
                return "No songs left. Starting from beginning.";
            }
        }*/


        /* public String getSonglistInfo()
         {

         }*/
        
    }
}
