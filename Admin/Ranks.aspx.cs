using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Ranks : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRankType();
                BindStudents();
                BindData();
            }
        }
        public void BindRankType()
        {
            sqlstmt = "";
            sqlstmt = "Select * from rank_type_trans";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropRankType.DataSource = ds.Tables[0];
                DropRankType.DataTextField = "rank_type_name";
                DropRankType.DataValueField = "rank_type_id";
                DropRankType.DataBind();
            }
            else
            {
                DropRankType.DataSource = System.DBNull.Value.ToString();
                DropRankType.DataBind();
            }
            DropRankType.Items.Insert(0, "--Select--");
        }
        public void BindStudents()
        {
            sqlstmt = "";
            sqlstmt = "Select * from student_master";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropStuName.DataSource = ds.Tables[0];
                DropStuName.DataTextField = "stu_name";
                DropStuName.DataValueField = "stu_id";
                DropStuName.DataBind();
            }
            else
            {
                DropStuName.DataSource = System.DBNull.Value.ToString();
                DropStuName.DataBind();
            }
            DropStuName.Items.Insert(0, "--Select--");
        }
        public void GetData()
        {
            var unique_id = ViewState["Id"].ToString();
            if (unique_id != null)
            {
                sqlstmt = "";
                sqlstmt = "Select * from rank_history where rank_history_id =" + unique_id.ToString();
                DataSet ds = cls.Select(sqlstmt);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DropRankType.SelectedValue = ds.Tables[0].Rows[0]["rank_type_id"].ToString();
                    DropStuName.SelectedValue = ds.Tables[0].Rows[0]["rank_stu_id"].ToString();
                }
            }

        }

        public void BindData()
        {
            sqlstmt = "";
            sqlstmt = "SELECT * FROM rank_history INNER JOIN student_master ON rank_history.rank_stu_id = student_master.stu_id INNER JOIN rank_type_trans ON rank_history.rank_type_id = rank_type_trans.rank_type_id";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Lst_Designation.DataSource = ds.Tables[0];
                Lst_Designation.DataBind();
            }
            else
            {
                Lst_Designation.DataSource = null;
            }
        }

        public void CrudOP()
        {
            //var unique_id = ViewState["Id"].ToString();
            if (ViewState["Id"] == null)
            {
                sqlstmt = "";
                sqlstmt = "Insert into rank_history (rank_type_id,rank_stu_id,rank_date) values ('" + DropRankType.SelectedValue + "','"+ DropStuName.SelectedValue +"','"+ DateTime.Now.ToString() +"')";
                cls.Insert(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Inserted..!')", true);
                Response.Redirect("Ranks.aspx");
                //ShowMessageBox("Activities.aspx","Record Inserted..!");    
            }
            else
            {
                sqlstmt = "";
                sqlstmt = "Update rank_history set rank_type_id = '" + DropRankType.SelectedValue + "', rank_stu_id = '"+ DropStuName.SelectedValue + "',rank_date = '"+ DateTime.Now.ToString() +"' where rank_history_id=" + ViewState["Id"].ToString();
                cls.Update(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Updated..!')", true);
                Response.Redirect("Ranks.aspx");
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
            sqlstmt = "Delete from rank_history where rank_history_id=" + ViewState["Id"].ToString();
            cls.Delete(sqlstmt);
            ShowMessageBox();
        }
        private void ShowMessageBox()
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "agree = confirm('Record Deleted...'); \n";
            sJavaScript += "if(agree)\n";
            sJavaScript += "window.location = \"Ranks.aspx\";\n";
            sJavaScript += "</script>";
            Response.Write(sJavaScript);
        }
    }
}