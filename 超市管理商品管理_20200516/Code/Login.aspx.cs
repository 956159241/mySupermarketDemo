using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using RL.DBUtility;

namespace mySupermarketDemo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //编写sql语句，此处的top 1 就是选出查询的第一条记录，此处可避免查出内容相同的两条语句
            //利用参数，防止sql注入
            string sql = "SELECT TOP 1 * FROM Users  WHERE UserName = @UserName AND Password = @Password";
            //设置参数
            SqlParameter[] pms = { 
                                    new SqlParameter("@UserName",SqlDbType.NVarChar,50),
                                    new SqlParameter("@Password",SqlDbType.NVarChar,50)
                                 };
            //为参数赋值
            pms[0].Value = txtUserName.Text;
            pms[1].Value = txtPassword.Text;
            /*
             *注意：DataSet 是个数据集，可以把它当做临时数据库来看。DataTable 是DataSet临时数据库里的临时表，
             * 一个DataSet 里可以有多个DataTable，就像一个数据库里可以有多个表一样
             */
            DataSet ds = DbHelperSQL.Query(sql, pms);        //执行查询，并将数据放置在一个数据集中
            //判断表中是否存在数据，如果有数据则登录成功，如果没哟数据，则登录失败
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["UserId"] = ds.Tables[0].Rows[0]["UserID"];//为userid设置缓存，为了之后的插入数据和防止用户跳过登录直接进入
                Response.Redirect("CommodityManage.aspx");//跳转页面
            }
                //验证失败弹出提示框
            else
            {
                Response.Write("<script>alert('用户名或密码错误，请重新登录');</script>");
            }
        }
    }
}