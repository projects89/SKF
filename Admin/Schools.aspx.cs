using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.Common;

namespace SKF.Admin
{
    public partial class Schools : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindSchoolData();
            }
        }

        public void BindSchoolData()
        {
            sqlstmt = "";
            sqlstmt = "Select * from school_master";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Lst_Schools.DataSource = ds.Tables[0];
                Lst_Schools.DataBind();
            }
            else
            {
                Lst_Schools.DataSource = null;
            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            string idn = lnk.CommandArgument.ToString();
            Response.Redirect("Add_School.aspx?id=" + idn);
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            string idn = lnk.CommandArgument.ToString();
            sqlstmt = "";
            sqlstmt = "Delete from school_master where school_id = " + idn.ToString();
            cls.Delete(sqlstmt);
            ShowMessageBox();
        }
        private void ShowMessageBox()
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "agree = confirm('Record Deleted...'); \n";
            sJavaScript += "if(agree)\n";
            sJavaScript += "window.location = \"Schools.aspx\";\n";
            sJavaScript += "</script>";
            Response.Write(sJavaScript);
        }
    }
}