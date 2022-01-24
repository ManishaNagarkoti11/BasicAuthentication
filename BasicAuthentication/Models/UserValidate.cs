using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthentication.Models
{
    //step 3:
    public class UserValidate
    {
        public static bool LogIn(string userName, string password)
        {
            UserBL userbl = new UserBL();
            var UserLists = userbl.GetUsers();
            return UserLists.Any(user => user.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) && user.Password == password);

            //StringComparison.OrdinalIgnoreCase check username byte to byte 
        }
    }
}