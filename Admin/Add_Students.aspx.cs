using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Add_Students : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSchool();
                var unique_id = Request.QueryString["id"];
                if (unique_id != null)
                {
                    GetData();
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

        public void GetData()
        {
            var unique_id = Request.QueryString["id"];
            sqlstmt = "";
            sqlstmt = "Select * from student_master where stu_id = " + unique_id.ToString();
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropSchooName.SelectedValue = ds.Tables[0].Rows[0]["stu_school_id"].ToString();
                txtStuName.Text = ds.Tables[0].Rows[0]["stu_name"].ToString();
                txtStuEmail.Text = ds.Tables[0].Rows[0]["stu_email"].ToString();
                txtStuPhone.Text = ds.Tables[0].Rows[0]["stu_phone"].ToString();
                txtStuZip.Text = ds.Tables[0].Rows[0]["stu_zip"].ToString();
                txtStuDOB.Text = ds.Tables[0].Rows[0]["stu_dob"].ToString();
                txtStuDOJ.Text = ds.Tables[0].Rows[0]["stu_join_date"].ToString();
            }
        }

        public void CrudOP()
        {
            var unique_id = Request.QueryString["id"];
            if (unique_id == null)
            {
                sqlstmt = "";
                sqlstmt = "Insert into student_master (stu_school_id,stu_name,stu_email,stu_phone,stu_zip,stu_dob,stu_join_date) values ('"+ DropSchooName.SelectedValue +"','"+ txtStuName.Text.Trim() +"','"+ txtStuEmail.Text.Trim() +"','"+ txtStuPhone.Text.Trim() +"','"+ txtStuZip.Text.Trim() +"','"+ txtStuDOB.Text.Trim() +"','"+ txtStuDOJ.Text.Trim() +"') ";
                cls.Insert(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Inserted..!')", true);
                Response.Redirect("Students.aspx");
                //ShowMessageBox("Activities.aspx","Record Inserted..!");    
            }
            else
            {
                sqlstmt = "";
                sqlstmt = "Update student_master set stu_school_id = '"+ DropSchooName.SelectedValue + "', stu_name = '"+ txtStuName.Text.Trim() + "',stu_phone = '" + txtStuPhone.Text.Trim() + "',stu_zip = '" + txtStuZip.Text.Trim() + "',stu_dob = '" + txtStuDOB.Text.Trim() + "',stu_join_date = '" + txtStuDOJ.Text.Trim() + "' where stu_id =" + unique_id.ToString();
                cls.Update(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Updated..!')", true);
                Response.Redirect("Students.aspx");
                //ShowMessageBox("Activities.aspx", "Record Updated..!");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CrudOP();
        }
    }
}