﻿using System;
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

        public String playSong()
        {
            return "\nCurrently playing: " + getTitle() + " by " + getArtistNames();
        }

        public String pauseSong()
        {
            return "\nPaused: " + getTitle() + " by " + getArtistNames();
        }

        public String displayInfo()
        {
            return "\nTitle: " + getTitle() + "\nArtists: " + getArtistNames() + "\nGenre: " + getGenre();
        }
    }
}
