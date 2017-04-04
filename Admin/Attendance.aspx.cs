using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Attendance : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindClassName();
                BindStudents();
                BindData();
            }
        }

        public void GetData()
        {
            var unique_id = ViewState["Id"].ToString();
            if (unique_id != null)
            {
                sqlstmt = "";
                sqlstmt = "Select * from attendance_master where attedance_id =" + unique_id.ToString();
                DataSet ds = cls.Select(sqlstmt);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DropClassName.SelectedValue = ds.Tables[0].Rows[0]["attendance_class_id"].ToString();
                    DropStuName.SelectedValue = ds.Tables[0].Rows[0]["attendance_stu_id"].ToString();
                }
            }

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
        public void BindClassName()
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
        public void BindData()
        {
            sqlstmt = "";
            sqlstmt = "SELECT * FROM attendance_master INNER JOIN class_master ON attendance_master.attendance_class_id = class_master.class_id INNER JOIN student_master ON attendance_master.attendance_stu_id = student_master.stu_id";
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
                sqlstmt = "Insert into attendance_master (attendance_class_id,attendance_stu_id) values ('" + DropClassName.SelectedValue + "','"+ DropStuName.SelectedValue +"')";
                cls.Insert(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Inserted..!')", true);
                Response.Redirect("Attendance.aspx");
                //ShowMessageBox("Activities.aspx","Record Inserted..!");    
            }
            else
            {
                sqlstmt = "";
                sqlstmt = "Update attendance_master set attendance_class_id = '" + DropClassName.SelectedValue + "',attendance_stu_id = '"+ DropStuName.SelectedValue + "' where attedance_id=" + ViewState["Id"].ToString();
                cls.Update(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Updated..!')", true);
                Response.Redirect("Attendance.aspx");
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
            sqlstmt = "Delete from attendance_master where attedance_id=" + ViewState["Id"].ToString();
            cls.Delete(sqlstmt);
            ShowMessageBox();
        }
        private void ShowMessageBox()
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "agree = confirm('Record Deleted...'); \n";
            sJavaScript += "if(agree)\n";
            sJavaScript += "window.location = \"Attendance.aspx\";\n";
            sJavaScript += "</script>";
            Response.Write(sJavaScript);
        }
    }
}