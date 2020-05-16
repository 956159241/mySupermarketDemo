using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using RL.DBUtility;
using System.Data.SqlClient;

namespace mySupermarketDemo
{
    public partial class UsersManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StringBuilder sbSql = new StringBuilder();//构造字符串，string会引入一些垃圾
                //sbSql.AppendLine("SELECT SortID,SortName FROM CommoditySort");//提前写好sql语句
                sbSql.AppendLine("SELECT UserName,Password FROM Users");

                DataSet ds = DbHelperSQL.Query(sbSql.ToString());
                gvUsers.DataSource = ds;
                gvUsers.DataBind();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvUsers.Rows.Count; i++)
            {
                string id = gvUsers.Rows[i].Cells[1].Text;
                CheckBox cb = gvUsers.Rows[i].FindControl("CheckBoxSel") as CheckBox;
                if (cb.Checked)
                {
                    string cName1 = gvUsers.Rows[i].Cells[1].Text;
                    string sql2 = "DELETE FROM dbo.Users WHERE UserName = @UserName";
                    SqlParameter[] pms2 ={
                                         new SqlParameter("@UserName",SqlDbType.NVarChar,50)
                                      };
                    pms2[0].Value = cName1;
                    DbHelperSQL.ExecuteSql(sql2, pms2);
                    Response.Write("<script>alert('删除成功');</script>");
                    Response.Redirect("UsersManage.aspx");
                }
            }
        }
    }
}