using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Register : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropType();
            }
        }
        public void DropType()
        {
            sqlstmt = "";
            sqlstmt = "Select * from login_type_master";
            DataSet ds = cls.Select(sqlstmt);
            if(ds.Tables[0].Rows.Count >0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DropUserType.DataSource = ds.Tables[0];
                    DropUserType.DataTextField = "login_type_name";
                    DropUserType.DataValueField = "login_type_id";
                    DropUserType.DataBind();
                }
                else
                {
                    DropUserType.DataSource = System.DBNull.Value.ToString();
                    DropUserType.DataBind();
                }
                DropUserType.Items.Insert(0, "--Select User Type--");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            int userType = Convert.ToInt32(DropUserType.SelectedValue.ToString());
            string fullName = txtFname.Text.Trim() + " " + txtLname.Text.Trim();
            sqlstmt = "";
            sqlstmt = "Insert into login_master login_uname = '"+ txtEmail.Text.Trim() +"', login_password = '"+ txtPassword.Text.Trim() +"', login_usertype = '"+ userType + "'";
            cls.Insert(sqlstmt);

            if (userType == 1)
            {
                sqlstmt = "";
                sqlstmt = "Insert into admin_master (admin_username,admin_fullname,admin_email,admin_phone,admin_zip) values ('"+ txtEmail.Text.Trim() +"', '"+ fullName.ToString() +"','"+ txtEmail.Text.Trim() +"','"+ txtPhone.Text.Trim() +"','"+ txtZip.Text.Trim() +"') ";
                cls.Select(sqlstmt);
            }
            //else if (userType == 2)
            //{
            //    sqlstmt = "";
            //    sqlstmt = "Insert into staff_master (staff_name,staff_email,staff_phone,staff_designation,staff_zip) values ('"+ fullName +"','"+ txtEmail.Text.Trim() +"','"+ txtPhone.Text.Trim() +"','"+ userType +"','"+ txtZip.Text.Trim() +"')";
            //    cls.Select(sqlstmt);
            //}
            //else if (userType == 3)
            //{
            //    sqlstmt = "";
            //    sqlstmt = "Insert into staff_master (staff_name,staff_email,staff_phone,staff_designation,staff_zip) values ('" + fullName + "','" + txtEmail.Text.Trim() + "','" + txtPhone.Text.Trim() + "','" + userType + "','" + txtZip.Text.Trim() + "')";
            //    cls.Select(sqlstmt);
            //}
            //else if (userType == 4)
            //{
            //    sqlstmt = "";
            //    sqlstmt = "Insert into student_master () values ()";
            //    cls.Select(sqlstmt);
            //}
            //else if (userType == 5)
            //{
            //    sqlstmt = "";
            //    sqlstmt = "";
            //    cls.Select(sqlstmt);
            //}

        }
    }
}