using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotivy
{
    internal class User(String name, String password)
    {
        int id;
        String name = name;
        private String password = password;

        public String getName()
        {
            return name;
        }
    }
}
