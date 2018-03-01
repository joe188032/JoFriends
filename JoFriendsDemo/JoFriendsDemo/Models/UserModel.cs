using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoFriendsDemo.Models
{
    public class UserModel
    {
        JofriendDataEntities db = new JofriendDataEntities();

        public bool LoginCheck(string email, string password)
        {


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
        public void GetUser(string email)
        {
            var user = db.users.FirstOrDefault(u => u.email == email);

        }
        public void Logout() {
            

        }
    }
}