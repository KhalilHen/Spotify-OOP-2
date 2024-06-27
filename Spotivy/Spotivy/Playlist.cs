using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotivy
{
    public class PlayList : Songlist
    {
        public PlayList(String title, List<Song> songs) : base(title, songs)
        {
        }

        }
}
