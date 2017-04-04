using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Add_School : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var unique_id = Request.QueryString["id"];
                if(unique_id != null)
                {
                    GetData();
                }
            }
        }

        public void GetData()
        {
            var unique_id = Request.QueryString["id"];
            sqlstmt = "";
            sqlstmt = "Select * from school_master where school_id = "+ unique_id.ToString();
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtSchoolName.Text = ds.Tables[0].Rows[0]["school_name"].ToString();
                txtSchoolEmail.Text = ds.Tables[0].Rows[0]["school_email"].ToString();
                txtschoolPhone.Text = ds.Tables[0].Rows[0]["school_phone"].ToString();
                txtSchoolZip.Text = ds.Tables[0].Rows[0]["school_zip"].ToString();
            }
        }

        public void CrudOP()
        {
            var unique_id = Request.QueryString["id"];
            if (unique_id == null)
            {
                sqlstmt = "";
                sqlstmt = "Insert into school_master (school_name,school_email,school_phone,school_zip) values ('"+ txtSchoolName.Text.Trim () +"','"+ txtSchoolEmail.Text.Trim() +"','"+ txtschoolPhone.Text.Trim() +"','"+ txtSchoolZip.Text.Trim() +"')";
                cls.Insert(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Inserted..!')", true);
                Response.Redirect("Schools.aspx");
                //ShowMessageBox("Activities.aspx","Record Inserted..!");    
            }
            else
            {
                sqlstmt = "";
                sqlstmt = "update school_master set school_name = '" + txtSchoolName.Text.Trim() + "',school_email = '"+ txtSchoolEmail.Text.Trim() + "', school_phone ='"+ txtschoolPhone.Text.Trim() + "', school_zip = '"+ txtSchoolZip.Text.Trim() +"' where school_id =" + unique_id.ToString();
                cls.Update(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Updated..!')", true);
                Response.Redirect("Schools.aspx");
                //ShowMessageBox("Activities.aspx", "Record Updated..!");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CrudOP();
        }
    }
}