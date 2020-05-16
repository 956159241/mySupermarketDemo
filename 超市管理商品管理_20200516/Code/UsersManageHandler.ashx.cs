using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using RL.DBUtility;

namespace mySupermarketDemo
{
    /// <summary>
    /// UsersManageHandler 的摘要说明
    /// </summary>
    public class UsersManageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.ContentType = "text/plain";
            //获取用户名
            string name = context.Request["name"];
            string password = context.Request["password"];
            //sql代码
            string sql = "SELECT UserID,Password FROM Users where UserName = @name";
            SqlParameter[] pms = {
                                   new SqlParameter("@name",SqlDbType.NVarChar,50)
                                 };
            pms[0].Value = name;
            DataSet ds = DbHelperSQL.Query(sql, pms);//执行sql语句，并利用DataSet将数据填充到本地内存中
            int myInt = Convert.ToInt32(ds.Tables[0].Rows.Count);
            //判断是否符合条件
            if (myInt > 0 || (name == null || name.Length == 0))
            {
                context.Response.Write("请检查输入是否规范");
            }
            else
            {
                string sqlMyInsert = "INSERT INTO Users(UserName,Password) values (@UserName,@Password);";
                SqlParameter[] pmsMyInsert = { 
                                        new SqlParameter("@UserName",SqlDbType.NVarChar,50),
                                        new SqlParameter("@Password",SqlDbType.NVarChar,50)
                                     };
                pmsMyInsert[0].Value = name;
                pmsMyInsert[1].Value = password;
                DbHelperSQL.ExecuteSql(sqlMyInsert, pmsMyInsert);

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}