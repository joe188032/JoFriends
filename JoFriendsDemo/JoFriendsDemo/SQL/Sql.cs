using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace JoFriendsDemo.SQL
{
    public class Sql
    {
        public  void SqlConnection(){

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();

            scsb.DataSource = @"jofriend-test.database.windows.net"; // 伺服器來源名稱
            scsb.IntegratedSecurity = false; // 是否使用Windows驗證
            scsb.UserID = "iiiteamno3"; // 此連線使用者ID
            scsb.Password = "P@ssword-123"; // 此連線使用者密碼
            scsb.InitialCatalog = "JoFeriend"; // 資料庫名稱

        }

    }
}