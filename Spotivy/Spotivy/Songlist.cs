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
        List<Person> personList;
        String songTitlesArtists;
        private int currentSongIndex;

        public Songlist(String title, List<Song> songs)
        {
            this.title = title;
            this.songs = songs;
            this.currentSongIndex = 0;
        }

        public String getTitle() { return title; }
        public List<Song> getSonglist() {  return songs; }
        public List<Person> getPersonList() {  return personList; }

        public String getSonglistToString()
        {
             songTitlesArtists = string.Empty;
             foreach (Song song in getSonglist())
             {
                 songTitlesArtists += song.getTitle() + " by " + song.getArtistNames() + "\n";
             }
             return songTitlesArtists;
        }

        public String playSonglist()
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

        }


        /* public String getSonglistInfo()
         {

         }*/
        
    }
}
