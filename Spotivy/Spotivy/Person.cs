using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotivy
{
    public class Person
    {
        internal String name;
        internal List<Songlist> songlistList;

        public Person(String name, List<Songlist> songlistList)
        {
            this.name = name;
            this.songlistList = songlistList;
        }
     
        public String getName()
        {
            return name;
        }
    }

}
