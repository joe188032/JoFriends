using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoFriendsDemo.Models
{
    public class GuestBookModel
    {
        JofriendDataEntities db = new JofriendDataEntities();


        public List<GuestBook> ReadComment(int CategoryID)
        {
            var Comment = from c in db.GuestBook
                          where c.CategoryID == CategoryID
                          select c;

            List<GuestBook> CommentList = new List<GuestBook>();

            foreach (var c in Comment)
                CommentList.Add(c);

            return CommentList;
        }


        public void PostComment(int Cid, int Uid, string NickName, string Comment)
        {
            GuestBook gb = new GuestBook();

            gb.CategoryID = Cid;
            gb.UserID = Uid;
            gb.NickName = NickName;
            gb.Comment = Comment;
            gb.Time = DateTime.Now;

            db.GuestBook.Add(gb);
            db.SaveChanges();

        }
    }
}
