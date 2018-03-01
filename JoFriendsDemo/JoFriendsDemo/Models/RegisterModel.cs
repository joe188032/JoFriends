using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoFriendsDemo.Models
{
    public class RegisterModel
    {
        JofriendDataEntities db = new JofriendDataEntities();

        public bool RegisterCheck(string Email) {

            var user = db.users.FirstOrDefault(m => m.email == Email);

            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    

    }
}