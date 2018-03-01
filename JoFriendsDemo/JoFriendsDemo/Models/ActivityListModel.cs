using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoFriendsDemo.Models
{
    public class ActivityListModel
    {
        JofriendDataEntities db = new JofriendDataEntities();

        public List<Activity> GetActivityList(int CategoryId)
        {

            var ActivityList = from a in db.Activity
                               where a.CategoryID==CategoryId
                               orderby a.ActivityID descending
                               select a;

            List<Activity> alist = new List<Activity>();

            foreach (var a in ActivityList)

                alist.Add(a);

            return alist;


        }

        public void Join(int UserId, int ActivityID)
        {

                ActivityDetail AD = new ActivityDetail();

                AD.UserID = UserId;
                AD.ActivityID = ActivityID;
                AD.CreateAt = DateTime.Now;

                db.ActivityDetail.Add(AD);
                db.SaveChanges();

        }

    }
}