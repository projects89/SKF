using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Classes : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSchool();
                BindClassLevel();
                BindData();
            }
        }

        public void GetData()
        {
            var unique_id = ViewState["Id"].ToString();
            if (unique_id != null)
            {
                sqlstmt = "";
                sqlstmt = "Select * from class_master where class_id =" + unique_id.ToString();
                DataSet ds = cls.Select(sqlstmt);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DropSchooName.Text = ds.Tables[0].Rows[0]["class_school_id"].ToString();
                    DropClassLevelType.Text = ds.Tables[0].Rows[0]["class_level_id"].ToString();
                    txtClassName.Text = ds.Tables[0].Rows[0]["class_name"].ToString();
                    txtClassStartDate.Text = ds.Tables[0].Rows[0]["class_start_date"].ToString();
                    txtClassEndDate.Text = ds.Tables[0].Rows[0]["class_end_date"].ToString();
                    txtClassStartTime.Text = ds.Tables[0].Rows[0]["class_start_time"].ToString();
                    txtClassEndTime.Text = ds.Tables[0].Rows[0]["class_end_time"].ToString();
                }
            }

        }

        public void BindSchool()
        {
            sqlstmt = "";
            sqlstmt = "Select * from school_master";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropSchooName.DataSource = ds.Tables[0];
                DropSchooName.DataTextField = "school_name";
                DropSchooName.DataValueField = "school_id";
                DropSchooName.DataBind();
            }
            else
            {
                DropSchooName.DataSource = System.DBNull.Value.ToString();
                DropSchooName.DataBind();
            }
            DropSchooName.Items.Insert(0, "--Select--");
        }

        public void BindClassLevel()
        {
            sqlstmt = "";
            sqlstmt = "Select * from class_level_master";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropClassLevelType.DataSource = ds.Tables[0];
                DropClassLevelType.DataTextField = "class_level_name";
                DropClassLevelType.DataValueField = "class_level_id";
                DropClassLevelType.DataBind();
            }
            else
            {
                DropClassLevelType.DataSource = System.DBNull.Value.ToString();
                DropClassLevelType.DataBind();
            }
            DropClassLevelType.Items.Insert(0, "--Select--");
        }

        public void BindData()
        {
            sqlstmt = "";
            sqlstmt = "SELECT * FROM class_master INNER JOIN school_master ON class_master.class_school_id = school_master.school_id INNER JOIN class_level_master ON class_master.class_level_id = class_level_master.class_level_id";
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
                sqlstmt = "Insert into class_master (class_school_id,class_level_id,class_name,class_start_date,class_end_date,class_start_time,class_end_time) values ('"+ DropSchooName.SelectedValue +"','"+ DropClassLevelType.SelectedValue +"','"+ txtClassName.Text.Trim() +"','"+ txtClassStartDate.Text.Trim() +"','"+ txtClassEndDate.Text.Trim() +"','"+ txtClassStartTime.Text.Trim() +"','"+ txtClassEndTime.Text.Trim() +"')";
                cls.Insert(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Inserted..!')", true);
                Response.Redirect("Classes.aspx");
                //ShowMessageBox("Activities.aspx","Record Inserted..!");    
            }
            else
            {
                sqlstmt = "";
                sqlstmt = "Update class_master set class_school_id = '" + DropSchooName.SelectedValue + "',class_level_id = '"+ DropClassLevelType.SelectedValue + "',class_name = '"+ txtClassName.Text.Trim() + "',class_start_date = '"+ txtClassStartDate.Text.Trim() + "',class_end_date = '"+ txtClassEndDate.Text.Trim()+ "',class_start_time = '"+ txtClassStartTime.Text.Trim() + "',class_end_time = '"+ txtClassEndTime.Text.Trim() +"' where class_id =" + ViewState["Id"].ToString();
                cls.Update(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Updated..!')", true);
                Response.Redirect("Classes.aspx");
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
            sqlstmt = "Delete from class_master where class_id=" + ViewState["Id"].ToString();
            cls.Delete(sqlstmt);
            ShowMessageBox();
        }
        private void ShowMessageBox()
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "agree = confirm('Record Deleted...'); \n";
            sJavaScript += "if(agree)\n";
            sJavaScript += "window.location = \"Classes.aspx\";\n";
            sJavaScript += "</script>";
            Response.Write(sJavaScript);
        }
    }
}