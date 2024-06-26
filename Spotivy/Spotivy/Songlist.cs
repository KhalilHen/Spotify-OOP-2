using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotivy
{
    public class Songlist
    {
        String title;
        List<Song> songs;
        List<Person> personList;

        public Songlist(String title, List<Song> songs)
        {
            this.title = title;
            this.songs = songs;
        }

        public String getTitle() { return title; }
        public List<Song> getSonglist() {  return songs; }
        public List<Person> getPersonList() {  return personList; }
    }
}
