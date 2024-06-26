﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotivy
{
    public class Person
    {
        String name;
        List<Songlist> songlistList;
        String songlistTitles;

        public Person(String name, List<Songlist> songlistList)
        {
            this.name = name;
            this.songlistList = songlistList;
        }
     
        public String getName()
        {
            return name;
        }

        public List<Songlist> getSonglistList()
        {
            return songlistList;
        }

        public String getSonglistListToString()
        {
            songlistTitles = string.Empty;
            foreach (Songlist songlist in getSonglistList())
            {
                songlistTitles += songlist.getTitle() + "\n";
            }
            return songlistTitles;
        }

        public String viewSonglistList()
        {
            return "";
        }
    }

}
