using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Instructors : System.Web.UI.Page
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
                sqlstmt = "Select * from instructor_master where inst_id =" + unique_id.ToString();
                DataSet ds = cls.Select(sqlstmt);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DropClassName.Text = ds.Tables[0].Rows[0]["inst_class_id"].ToString();
                    DropInstLevelType.Text = ds.Tables[0].Rows[0]["inst_class_level_id"].ToString();
                    txtInstName.Text = ds.Tables[0].Rows[0]["inst_name"].ToString();
                    txtInstEmail.Text = ds.Tables[0].Rows[0]["inst_email"].ToString();
                    txtInstPhone.Text = ds.Tables[0].Rows[0]["inst_phone"].ToString();
                    txtInstZip.Text = ds.Tables[0].Rows[0]["inst_zip"].ToString();
                }
            }

        }

        public void BindSchool()
        {
            sqlstmt = "";
            sqlstmt = "Select * from class_master";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropClassName.DataSource = ds.Tables[0];
                DropClassName.DataTextField = "class_name";
                DropClassName.DataValueField = "class_id";
                DropClassName.DataBind();
            }
            else
            {
                DropClassName.DataSource = System.DBNull.Value.ToString();
                DropClassName.DataBind();
            }
            DropClassName.Items.Insert(0, "--Select--");
        }

        public void BindClassLevel()
        {
            sqlstmt = "";
            sqlstmt = "Select * from class_level_master";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropInstLevelType.DataSource = ds.Tables[0];
                DropInstLevelType.DataTextField = "class_level_name";
                DropInstLevelType.DataValueField = "class_level_id";
                DropInstLevelType.DataBind();
            }
            else
            {
                DropInstLevelType.DataSource = System.DBNull.Value.ToString();
                DropInstLevelType.DataBind();
            }
            DropInstLevelType.Items.Insert(0, "--Select--");
        }

        public void BindData()
        {
            sqlstmt = "";
            sqlstmt = "SELECT * FROM instructor_master INNER JOIN class_master ON instructor_master.inst_class_id = class_master.class_id INNER JOIN class_level_master ON instructor_master.inst_class_level_id = class_level_master.class_level_id INNER JOIN school_master ON class_master.class_school_id = school_master.school_id";
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
                sqlstmt = "Insert into instructor_master (inst_class_id,inst_class_level_id,inst_name,inst_email,inst_phone,inst_zip) values ('" + DropClassName.SelectedValue + "','" + DropInstLevelType.SelectedValue + "','" + txtInstName.Text.Trim() + "','" + txtInstEmail.Text.Trim() + "','" + txtInstPhone.Text.Trim() + "','" + txtInstZip.Text.Trim() + "')";
                cls.Insert(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Inserted..!')", true);
                Response.Redirect("Instructors.aspx");
                //ShowMessageBox("Activities.aspx","Record Inserted..!");    
            }
            else
            {
                sqlstmt = "";
                sqlstmt = "Update instructor_master set inst_class_id = '" + DropClassName.SelectedValue + "',inst_class_level_id = '" + DropInstLevelType.SelectedValue + "',inst_name = '" + txtInstName.Text.Trim() + "',inst_email = '" + txtInstEmail.Text.Trim() + "',inst_phone = '" + txtInstPhone.Text.Trim() + "',inst_zip = '" + txtInstZip.Text.Trim() + "' where inst_id =" + ViewState["Id"].ToString();
                cls.Update(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Updated..!')", true);
                Response.Redirect("Instructors.aspx");
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
            sqlstmt = "Delete from instructor_master where inst_id=" + ViewState["Id"].ToString();
            cls.Delete(sqlstmt);
            ShowMessageBox();
        }
        private void ShowMessageBox()
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "agree = confirm('Record Deleted...'); \n";
            sJavaScript += "if(agree)\n";
            sJavaScript += "window.location = \"Instructors.aspx\";\n";
            sJavaScript += "</script>";
            Response.Write(sJavaScript);
        }
    }
}