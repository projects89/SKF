using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Add_Staff : System.Web.UI.Page
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
            sqlstmt = "Select * from staff_master where staff_id = " + unique_id.ToString();
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropSchooName.SelectedValue = ds.Tables[0].Rows[0]["school_id"].ToString();
                DropUser_Type.Text = ds.Tables[0].Rows[0]["staff_usertype"].ToString();
                txtStaffName.Text = ds.Tables[0].Rows[0]["staff_name"].ToString();
                txtStaffEmail.Text = ds.Tables[0].Rows[0]["staff_email"].ToString();
                txtStaffPhone.Text = ds.Tables[0].Rows[0]["staff_phone"].ToString();
                txtStaffZip.Text = ds.Tables[0].Rows[0]["staff_zip"].ToString();
            }
        }

        public void CrudOP()
        {
            var unique_id = Request.QueryString["id"];
            if (unique_id == null)
            {
                sqlstmt = "";
                sqlstmt = "Insert into staff_master (school_id,staff_usertype,staff_name,staff_email,staff_phone,staff_zip) values ('"+ DropSchooName.SelectedValue +"','"+ DropUser_Type.SelectedItem +"','"+ txtStaffName.Text.Trim() +"','"+ txtStaffEmail.Text.Trim() +"','"+ txtStaffPhone.Text.Trim() +"','"+ txtStaffZip.Text.Trim() +"')";
                cls.Insert(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Inserted..!')", true);
                Response.Redirect("Staff.aspx");
                //ShowMessageBox("Activities.aspx","Record Inserted..!");    
            }
            else
            {
                sqlstmt = "";
                sqlstmt = "Update staff_master set school_id = '"+ DropSchooName.SelectedValue + "', staff_usertype = '"+ DropUser_Type.SelectedItem + "', staff_name = '"+ txtStaffName.Text.Trim() + "',staff_email = '"+ txtStaffEmail.Text.Trim() + "',staff_phone = '"+ txtStaffPhone.Text.Trim() +"' where staff_id ="+ unique_id.ToString();
                cls.Update(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Updated..!')", true);
                Response.Redirect("Staff.aspx");
                //ShowMessageBox("Activities.aspx", "Record Updated..!");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CrudOP();
        }
    }
}