using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthentication.Models
{
    //step 2:
    // create a business layer which will return the list of the users
    public class UserBL
    {

        //method that return the list of the users
        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            userList.Add( new User()
                {
                ID=1,
                UserName="Manisha",
                Password="1234"
            });
            userList.Add(new User()
            {
                ID = 2,
                UserName = "Subham",
                Password = "5678"
            });
            return userList;
        }
    }
}