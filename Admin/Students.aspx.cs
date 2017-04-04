using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Students : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            sqlstmt = "";
            sqlstmt = "SELECT * FROM student_master INNER JOIN school_master ON student_master.stu_school_id = school_master.school_id";
            DataSet ds = cls.Select(sqlstmt);
            if(ds.Tables[0].Rows.Count>0)
            {
                Lst_Student.DataSource = ds.Tables[0];
                Lst_Student.DataBind();
            }
            else
            {
                Lst_Student.DataSource = null;
            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            string idn = lnk.CommandArgument.ToString();
            Response.Redirect("Add_Students.aspx?id=" + idn);
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            string idn = lnk.CommandArgument.ToString();
            sqlstmt = "";
            sqlstmt = "Delete from student_master where stu_id = " + idn.ToString();
            cls.Delete(sqlstmt);
            ShowMessageBox();
        }
        private void ShowMessageBox()
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "agree = confirm('Record Deleted...'); \n";
            sJavaScript += "if(agree)\n";
            sJavaScript += "window.location = \"Students.aspx\";\n";
            sJavaScript += "</script>";
            Response.Write(sJavaScript);
        }
    }
}