using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Rank_Type : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindActivity();
                BindData();
            }
        }

        public void GetData()
        {
            var unique_id = ViewState["Id"].ToString();
            if (unique_id != null)
            {
                sqlstmt = "";
                sqlstmt = "Select * from rank_type_trans where rank_type_id =" + unique_id.ToString();
                DataSet ds = cls.Select(sqlstmt);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtRankTypeName.Text = ds.Tables[0].Rows[0]["rank_type_name"].ToString();
                    txtrankTypeDesc.Text = ds.Tables[0].Rows[0]["rank_type_description"].ToString();
                    txtRankTypeReq.Text = ds.Tables[0].Rows[0]["rank_requirement"].ToString();
                    DropActivityName.SelectedValue = ds.Tables[0].Rows[0]["rank_activity_id"].ToString();
                }
            }

        }

        public void BindActivity()
        {
            sqlstmt = "";
            sqlstmt = "Select * from activity_master";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropActivityName.DataSource = ds.Tables[0];
                DropActivityName.DataTextField = "activity_name";
                DropActivityName.DataValueField = "activity_id";
                DropActivityName.DataBind();
            }
            else
            {
                DropActivityName.DataSource = System.DBNull.Value.ToString();
                DropActivityName.DataBind();
            }
            DropActivityName.Items.Insert(0, "--Select--");
        }

        public void BindData()
        {
            sqlstmt = "";
            sqlstmt = "SELECT * FROM activity_master INNER JOIN rank_type_trans ON activity_master.activity_id = rank_type_trans.rank_activity_id";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Lst_RankType.DataSource = ds.Tables[0];
                Lst_RankType.DataBind();
            }
            else
            {
                Lst_RankType.DataSource = null;
            }
        }

        public void CrudOP()
        {
            //var unique_id = ViewState["Id"].ToString();
            if (ViewState["Id"] == null)
            {
                sqlstmt = "";
                sqlstmt = "Insert into rank_type_trans (rank_type_name,rank_type_description,rank_requirement,rank_activity_id) values ('" + txtRankTypeName.Text.Trim() + "','" + txtrankTypeDesc.Text.Trim() + "','" + txtRankTypeReq.Text.Trim() + "','" + DropActivityName.SelectedValue + "')";
                cls.Insert(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Inserted..!')", true);
                Response.Redirect("Rank_Type.aspx");
                //ShowMessageBox("Activities.aspx","Record Inserted..!");    
            }
            else
            {
                sqlstmt = "";
                sqlstmt = "Update rank_type_trans set rank_type_name = '" + txtRankTypeName.Text.Trim() + "',rank_type_description = '"+ txtrankTypeDesc.Text.Trim() + "',rank_requirement = '"+ txtRankTypeReq.Text.Trim() + "',rank_activity_id = '"+DropActivityName.SelectedValue + "' where rank_type_id=" + ViewState["Id"].ToString();
                cls.Update(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Updated..!')", true);
                Response.Redirect("Rank_Type.aspx");
                //ShowMessageBox("Activities.aspx", "Record Updated..!");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CrudOP();
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            ViewState["Id"] = lnk.CommandArgument.ToString();
            GetData();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            ViewState["Id"] = lnk.CommandArgument.ToString();
            sqlstmt = "";
            sqlstmt = "Delete from rank_type_trans where rank_type_id=" + ViewState["Id"].ToString();
            cls.Delete(sqlstmt);
            ShowMessageBox();
        }
        private void ShowMessageBox()
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "agree = confirm('Record Deleted...'); \n";
            sJavaScript += "if(agree)\n";
            sJavaScript += "window.location = \"Rank_Type.aspx\";\n";
            sJavaScript += "</script>";
            Response.Write(sJavaScript);
        }
    }
}