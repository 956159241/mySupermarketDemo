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
    public partial class CommodityEdit : System.Web.UI.Page
    {
        private int cId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.AllKeys.Contains("cid"))
            {
                cId = int.Parse(Request.QueryString["cid"]);
            }
            if (!IsPostBack)
            {
                BindDrop();
                if (cId != 0)
                {
                    ShowInfo(cId);
                }
            }
        }
        //绑定下拉菜单
        private void BindDrop()
        {
            string sql = "SELECT SortID ,SortName FROM dbo.CommoditySort";
            DataSet ds = DbHelperSQL.Query(sql);
            ddlSort.DataSource = ds;
            ddlSort.DataTextField = "SortName";
            ddlSort.DataValueField = "SortID";
            ddlSort.DataBind();
        }
        //编辑信息
        private void ShowInfo(int id)
        {
            string sql = "SELECT	CommodityID ,CommodityName ,SortID , CommodityPrice ,IsDiscount ,ReducedPrice FROM dbo.Commodity WHERE CommodityID = " + cId;
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow drCurrent = ds.Tables[0].Rows[0];
                txtCName.Text = drCurrent["CommodityName"].ToString();
                ddlSort.SelectedValue = drCurrent["SortID"].ToString();
                txtPrice.Text = drCurrent["CommodityPrice"].ToString();
                cbIsDiscount.Checked = bool.Parse(drCurrent["IsDiscount"].ToString());
                txtDisPrice.Text = drCurrent["ReducedPrice"].ToString();
            }
        }
        //关闭按钮点击事件，返回商品管理界面
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("CommoditySort.aspx"); 
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtCName.Text;//商品名称
            decimal price = Convert.ToDecimal(txtPrice.Text);//商品价格
            if (txtDisPrice.Text == "")//若果商品价格没填写则打折价格为原商品价格
            {
                txtDisPrice.Text = txtPrice.Text;
            }
            decimal reducePrice = Convert.ToDecimal(txtDisPrice.Text);//打折价格
            int sortID = int.Parse(ddlSort.SelectedValue);
            //获取是否打折
            bool isDicount = cbIsDiscount.Checked;
            int UserID = Convert.ToInt32(Session["UserId"]);
            if (UserID == 0)//测试用的，这样就可以在不经过用户登录而得到UserID
            {
                UserID = 1;
            }
            //修改信息(更新商品信息)
            cId = Convert.ToInt32(Request.QueryString["cid"]);
            if (cId != 0)
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("UPDATE Commodity SET ");
                sbSql.Append("CommodityName = @CommodityName,SortID = @SortID,CommodityPrice = ");
                sbSql.Append("@CommodityPrice,IsDiscount = @IsDiscount,");
                sbSql.Append("ReducedPrice = @ReducedPrice WHERE CommodityID = @cId");
                SqlParameter[] pms = { 
                                    new SqlParameter("@CommodityName",SqlDbType.NVarChar,50),
                                    new SqlParameter("@SortID",SqlDbType.Int),
                                    new SqlParameter("@CommodityPrice",SqlDbType.Decimal),
                                    new SqlParameter("@IsDiscount",SqlDbType.Bit),
                                    new SqlParameter("@ReducedPrice",SqlDbType.Decimal),
                                    new SqlParameter("@cId",SqlDbType.Int)
                                 };//创建参数
                pms[0].Value = name;//为参数赋值
                pms[1].Value = sortID;//为参数赋值
                pms[2].Value = price;//为参数赋值
                pms[3].Value = isDicount;//为参数赋值
                pms[4].Value = reducePrice;//为参数赋值
                pms[5].Value = cId;//为参数赋值
                DbHelperSQL.ExecuteSql(sbSql.ToString(), pms);
            }
            //保存商品信息
            else
            {  
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("INSERT INTO Commodity(");
                sbSql.Append("CommodityName,SortID,CommodityPrice,IsDiscount,ReducedPrice,CreateUserId)");
                sbSql.Append("VALUES(@CommodityName,@SortID,@CommodityPrice,@IsDiscount,@ReducedPrice,@CreateUserId)");
                SqlParameter[] pms = { 
                                    new SqlParameter("@CommodityName",SqlDbType.NVarChar,50),
                                    new SqlParameter("@SortID",SqlDbType.Int),
                                    new SqlParameter("@CommodityPrice",SqlDbType.Decimal),
                                    new SqlParameter("@IsDiscount",SqlDbType.Bit),
                                    new SqlParameter("@ReducedPrice",SqlDbType.Decimal),
                                    new SqlParameter("@CreateUserId",SqlDbType.Int)
                                 };//创建参数
                pms[0].Value = name;//为参数赋值
                pms[1].Value = sortID;//为参数赋值
                pms[2].Value = price;//为参数赋值
                pms[3].Value = isDicount;//为参数赋值
                pms[4].Value = reducePrice;//为参数赋值
                pms[5].Value = UserID;
                DbHelperSQL.ExecuteSql(sbSql.ToString(), pms);
            }
            Response.Redirect("CommodityManage.aspx");
            }
    }
}