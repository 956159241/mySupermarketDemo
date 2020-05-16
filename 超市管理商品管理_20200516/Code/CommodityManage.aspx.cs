using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RL.DBUtility;
using System.Text;
using System.Data.SqlClient;

namespace mySupermarketDemo
{
    public partial class CommodityManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDrop();
                BindData();
            }

        }
        // 绑定下拉框
        private void BindDrop()
        {
            //获取分类ID和分类名称
            string sql = "SELECT SortID,SortName FROM dbo.CommoditySort";
            DataSet ds = DbHelperSQL.Query(sql);//将查询结果放入数据集ds中
            ddlSort.DataSource = ds;//将数据源放至下拉菜单中
            DataRow drNew = ds.Tables[0].NewRow();//方法，新建一行
            drNew["SortID"] = 0;//为新增的一行添加两个属性
            drNew["SortName"] = "全部";
            ds.Tables[0].Rows.InsertAt(drNew,0);//将新增的一行添加到ds中
            ddlSort.DataTextField = "SortName";//为下拉菜单设置初始值
            ddlSort.DataValueField = "SortID";
            ddlSort.DataBind();
        }
        //绑定数据
        private void BindData()
        {
            //首先获取选定值得ID
            int typeId = int.Parse(ddlSort.SelectedValue);
            string goodName = txtCName.Text;
            //采用字符串构造器的方式，写sql语句
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendLine("SELECT c.CommodityID,c.CommodityName ,t.SortName,c.CommodityPrice,c.IsDiscount,c.ReducedPrice ");
            sbSql.AppendLine("FROM dbo.Commodity AS c");
            sbSql.AppendLine("INNER JOIN dbo.CommoditySort AS t");
            sbSql.AppendLine("ON c.SortID = t.SortID");
            sbSql.AppendLine("WHERE 1=1");
            if (typeId != 0)
            {
                sbSql.AppendLine("AND c.SortID = @SortID");
            }
            if (!string.IsNullOrEmpty(goodName))
            {
                sbSql.AppendLine("AND c.CommodityName LIKE @GoodName");
            }
            SqlParameter[] pms = {
                                     new SqlParameter("@SortID",SqlDbType.Int,4),
                                     new SqlParameter("@GoodName",SqlDbType.VarChar,50)
                                 };
            pms[0].Value = typeId;
            pms[1].Value = "%" + goodName + "%";
            DataSet ds = DbHelperSQL.Query(sbSql.ToString(), pms);
            gvCommodity.DataSource = ds;
            gvCommodity.DataBind();
        
        }
        //触发搜索按钮事件
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        //触发删除按钮事件
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            StringBuilder sbIds = new StringBuilder();
            //获取gridview里的checkbox是否被选中
            foreach (GridViewRow gvr in gvCommodity.Rows)
            {
                CheckBox cbSelect = gvr.FindControl("cbSelection") as CheckBox;
                if (cbSelect.Checked)
                {
                    sbIds.Append(gvCommodity.DataKeys[gvr.RowIndex]["CommodityID"] + ",");
                }
            }
            //todo Delete From Table Where ID IN (1,2,3,4..)
            sbIds.Remove(sbIds.Length-1,1);//移除最后一个逗号
            //判断选中了一个，还是选中了多个进行删除
            if (sbIds.Length - 1 > 1)
            {
                sbIds.Insert(0, "DELETE FROM dbo.Commodity WHERE CommodityID in (");
                sbIds.Insert(sbIds.Length,")");
            }
            else
            {
                sbIds.Insert(0, "DELETE FROM dbo.Commodity WHERE CommodityID = ");
            }
            DbHelperSQL.ExecuteSql(sbIds.ToString());
            Response.Write("<script>alert('删除成功');</script>");
            Response.Redirect("CommodityManage.aspx");
        }
    }
}