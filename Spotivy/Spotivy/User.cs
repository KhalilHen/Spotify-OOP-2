using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Spotivy
{
    internal class User : Person
    {
        List<User> friendlist;

        public String getName()
        {
            return name;
        }
    }

    
}
