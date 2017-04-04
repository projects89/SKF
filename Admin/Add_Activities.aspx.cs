using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Add_Activities : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var unique_id = Request.QueryString["id"];
                if (unique_id != null)
                {
                    GetData();
                }
            }
        }
        public void GetData()
        {
            var unique_id = Request.QueryString["id"];
            sqlstmt = "";
            sqlstmt = "Select * from activity_master where activity_id"+ unique_id.ToString();
            DataSet ds = cls.Select(sqlstmt);
            if(ds.Tables[0].Rows.Count > 0)
            {
                txtActivity_Name.Text = ds.Tables[0].Rows[0]["activity_name"].ToString();
                txtActivity_Info.Text = ds.Tables[0].Rows[0]["activity_description"].ToString();
            }
        }
        public void CrudOP()
        {
            var unique_id = Request.QueryString["id"];
            if(unique_id == null)
            {
                sqlstmt = "";
                sqlstmt = "Insert into activity_master (activity_name,activity_description) values ('"+ txtActivity_Name.Text.Trim() +"','"+ txtActivity_Info.Text.Trim() +"')";
                cls.Insert(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Inserted..!')", true);
                Response.Redirect("Activities.aspx");
                //ShowMessageBox("Activities.aspx","Record Inserted..!");    
            }
            else
            {
                sqlstmt = "";
                sqlstmt = "Update activity_master set activity_name = '"+ txtActivity_Name.Text.Trim() + "', activity_description = '"+ txtActivity_Info.Text.Trim() +"' where activity_id = "+ unique_id.ToString();
                cls.Update(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Updated..!')", true);
                Response.Redirect("Activities.aspx");
                //ShowMessageBox("Activities.aspx", "Record Updated..!");
            }
        }
        private void ShowMessageBox(string sURL, string mSG)
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "agree = confirm("+ mSG +"); \n";
            sJavaScript += "if(agree)\n";
            sJavaScript += "window.location = \"" + sURL + "\";\n";
            sJavaScript += "</script>";
            Response.Write(sJavaScript);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CrudOP();
        }
    }
}