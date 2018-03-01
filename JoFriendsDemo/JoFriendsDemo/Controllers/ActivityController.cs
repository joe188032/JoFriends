using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoFriendsDemo.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace JoFriendsDemo.Controllers
{
    public class ActivityController : Controller
    {

        JofriendDataEntities db = new JofriendDataEntities();
        List<Activity> activitylist = new List<Activity>();

        public ActionResult ActivityList()
        {
            int cid = Convert.ToInt32(Request.QueryString["cid"]);

            ActivityListModel AListModel = new ActivityListModel();
            GuestBookModel GModel = new GuestBookModel();

            List<Activity> alist = AListModel.GetActivityList(cid);
            List<GuestBook> glist = GModel.ReadComment(cid);

            ViewData["AList"] = alist;
            ViewData["GList"] = glist;
            ViewData["CategoryID"] = cid;

            return View();
        }

        [HttpPost]
        public ActionResult CreateActivity()
        {
            ActivityModel AModel = new ActivityModel();
            ActivityListModel AListModel = new ActivityListModel();

            //List<Activity> AList = new List<Activity>();

            AModel.UserId = Convert.ToInt32(Session["UserId"]);
            AModel.ACategoryId = Convert.ToInt32(Request.Form["Category"]);
            AModel.AName = Request.Form["Title"];
            AModel.ALocation = Request.Form["Address"];
            AModel.AStartTime = Request.Form["BeginAt"];
            AModel.AEndTime = Request.Form["EndAt"];
            AModel.APhone = Request.Form["Phone"];
            AModel.AContent = Request.Form["Content"];
            AModel.ATotalPeople = Convert.ToInt32(Request.Form["TotalPeople"]);
            AModel.ACost = Request.Form["Cost"];

            AModel.Create();

            return View();
        }

        public ActionResult ReadMore() {

            string Title = Request.QueryString["Title"];

            Activity Detail = db.Activity.FirstOrDefault(d => d.Title==Title);

            ViewData["ActivityDetail"] = Detail;

            return View();
        }

        public  ActionResult Join (int Uid,int Aid) {

            ActivityListModel AL = new ActivityListModel();
            Aid=Convert.ToInt32(Request.QueryString["aid"]);
            AL.Join(Uid,Aid);

            return new RedirectResult("~/Activity/ReadMore");
        }
        
        [HttpPost]
        public ActionResult PostComment(Comment comment)
        {
            users user = Session["User"] as users;

            GuestBookModel gb = new GuestBookModel();

            gb.PostComment(comment.CategoryID ,user.userID,user.nickname,
                comment.comment);

            return Json(comment.comment,JsonRequestBehavior.AllowGet);
        }

    }
}
