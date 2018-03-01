using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoFriendsDemo.Models
{
    public class LoginModel
    {
        public bool LoginCheck(string email, string password)
        {

            JofriendEntities db = new JofriendEntities();

            var Users = db.users.FirstOrDefault(m => m.email == email);

            if (Users == null)
            {
                return false;
            }
            else
            {
                if (Users.password.Equals(password))
                {
                    return true;
                }
                return false;
            }
        }


    }
}