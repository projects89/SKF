using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Staff : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindStaff();
            }
        }

        public void BindStaff()
        {
            sqlstmt = "";
            sqlstmt = "SELECT * FROM staff_master INNER JOIN school_master ON staff_master.school_id = school_master.school_id ";
            DataSet ds = cls.Select(sqlstmt);
            if(ds.Tables[0].Rows.Count>0)
            {
                Lst_Staff.DataSource = ds.Tables[0];
                Lst_Staff.DataBind();
            }
            else
            {
                Lst_Staff.DataSource = null;
            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            string idn = lnk.CommandArgument.ToString();
            Response.Redirect("Add_Staff.aspx?id=" + idn);
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            string idn = lnk.CommandArgument.ToString();
            sqlstmt = "";
            sqlstmt = "Delete from staff_master where staff_id = " + idn.ToString();
            cls.Delete(sqlstmt);
            ShowMessageBox();
        }
        private void ShowMessageBox()
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "agree = confirm('Record Deleted...'); \n";
            sJavaScript += "if(agree)\n";
            sJavaScript += "window.location = \"Staff.aspx\";\n";
            sJavaScript += "</script>";
            Response.Write(sJavaScript);
        }
    }
}