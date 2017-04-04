using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Activities : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindActivities();
            }
        }
        public void BindActivities()
        {
            sqlstmt = "";
            sqlstmt = "Select * from activity_master";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Lst_Activities.DataSource = ds.Tables[0];
                Lst_Activities.DataBind();
            }
            else
            {
                Lst_Activities.DataSource = null;
            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            string idn = lnk.CommandArgument.ToString();
            Response.Redirect("Add_Activities.aspx?id=" + idn);
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            string idn = lnk.CommandArgument.ToString();
            sqlstmt = "";
            sqlstmt = "Delete from activity_master where activity_id = " + idn.ToString();
            cls.Delete(sqlstmt);
            ShowMessageBox();
        }
        private void ShowMessageBox()
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "agree = confirm('Record Deleted...'); \n";
            sJavaScript += "if(agree)\n";
            sJavaScript += "window.location = \"Activities.aspx\";\n";
            sJavaScript += "</script>";
            Response.Write(sJavaScript);
        }
    }
}