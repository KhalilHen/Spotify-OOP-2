using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Spotivy
{
    public class User : Person
    {
        List<User> friendlist;

        public User(string name, List<Songlist> songlistList, List<User> friendlist) : base(name, songlistList)
        {
            this.friendlist = friendlist;






        }
        public void userList(List<User> users, User currentUser)
        {





            foreach (User user in users)
            {

            
                if (user  != currentUser)
                {

                    Console.WriteLine(user.getName());

                }





            }


            






        }


    }

}
