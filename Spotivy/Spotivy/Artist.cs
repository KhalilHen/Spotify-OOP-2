﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotivy
{
    public class Artist : Person
    {
        List<Song> singles;

        public Artist(string name, List<Songlist> songlistList, List<Song> singles) : base(name, songlistList)
        {
            this.singles = singles;
        }
    }
}
