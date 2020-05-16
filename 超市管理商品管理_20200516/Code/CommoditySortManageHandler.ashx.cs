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
    /// CommoditySortManageHandler 的摘要说明
    /// </summary>
    public class CommoditySortManageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //获取商品名
            string name =  context.Request["name"];
            //sql代码
            string sql = "SELECT SortID FROM CommoditySort where SortName = @name";
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
                string sqlMyInsert = "INSERT INTO	CommoditySort(SortName) values (@SortName);";
                SqlParameter[] pmsMyInsert = { 
                                        new SqlParameter("@SortName",SqlDbType.NVarChar,50)
                                     };
                pmsMyInsert[0].Value = name;
                DbHelperSQL.ExecuteSql(sqlMyInsert,pmsMyInsert);
                
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