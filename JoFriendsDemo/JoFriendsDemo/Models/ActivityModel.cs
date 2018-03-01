using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace JoFriendsDemo.Models
{
    public class ActivityModel
    {
        
        JofriendDataEntities db = new JofriendDataEntities();

        Activity activity = new Activity();

        List<object> Activity = new List<object>();

        public int UserId { get; set; }
        public int ACategoryId { get; set; }
        public string AName { get; set; }
        public string ALocation { get; set; }
        public string AStartTime { get; set; }
        public string AEndTime { get; set; }
        public string APhone { get; set; }
        public string AContent { get; set; }
        public string AOrganiser { get; set; }
        public int ATotalPeople { get; set; }
        public string ACost { get; set; }
        public string Alongitude { get; set; }
        public string ALatitude { get; set; }
        

        public void Create(){

            activity.UserID = UserId;
            activity.CategoryID = ACategoryId;
            activity.Title = AName;
            activity.Content = AContent;
            activity.Address = ALocation;
            activity.BeginAt = Convert.ToDateTime(AStartTime);
            activity.EndAt =   Convert.ToDateTime(AEndTime);
            activity.Phone = APhone;
            activity.Total_person = ATotalPeople;
            activity.CreateAt = DateTime.Now;

            db.Activity.Add(activity);
            db.SaveChanges();

        }

    }
}