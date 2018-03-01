using JoFriendsDemo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoFriendsDemo.Controllers
{
    public class UserController : Controller
    {

        JofriendDataEntities db = new JofriendDataEntities();

        UserModel U = new UserModel();

        List<users> OnlineUser = new List<users>(); 
        
        // GET: User
        public ActionResult RegisterView()
        {
            return new RedirectResult("~/Home/Index");
        }

        [HttpPost]
        public ActionResult Register() {

            RegisterModel rs = new RegisterModel(); 

            string Email = Request.Form["Account"].ToString();
            string Password = Request.Form["Password"].ToString();
            string NickName = Request.Form["NickName"].ToString();
            string Name = Request.Form["Name"].ToString();
            string Mobile = Request.Form["Mobile"].ToString();
            string Address = Request.Form["Address"].ToString();


            bool result = rs.RegisterCheck(Email);
            if (result)
            {
                users us = new users();
                us.email = Email;
                us.password = Password;
                us.nickname = NickName;
                us.name = Name;
                us.mobile = Mobile;
                us.address = Address;
                us.createAt = DateTime.Now;

                db.users.Add(us);
                db.SaveChanges();

                return new RedirectResult("~");
                
            }
            else
            {

                return new RedirectResult("~");
            }
        }
        public ActionResult Login() {

            string Email = Request.Form["Account"].ToString();
            string Password = Request.Form["Password"].ToString();
            bool result = U.LoginCheck(Email, Password);

            if (result)
            {
                users us = db.users.FirstOrDefault(m=>m.email==Email);
                Session["User"] = us;

                return new RedirectResult("~");

            }
            else {

                JObject message = new JObject();

                message.Add("error", "帳號密碼錯誤!");
                return Content(JsonConvert.SerializeObject(message), "application/json");

            }
            
        }
        public ActionResult Logout()
        {
            U.Logout();

            Session.RemoveAll();

            OnlineUser.Clear();

            return new RedirectResult("~");

        }
    }
}