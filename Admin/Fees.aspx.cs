using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Fees : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            sqlstmt = "";
            sqlstmt = "SELECT * FROM bill_master INNER JOIN student_master ON bill_master.bill_stu_id = student_master.stu_id INNER JOIN school_master ON student_master.stu_school_id = school_master.school_id INNER JOIN staff_master ON bill_master.bill_receiver_id = staff_master.staff_id INNER JOIN bill_type ON bill_master.bill_type_id = bill_type.bill_type_id";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
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
            Response.Redirect("Add_Fees.aspx?id=" + idn);
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            string idn = lnk.CommandArgument.ToString();
            sqlstmt = "";
            sqlstmt = "Delete from bill_master where bill_id = " + idn.ToString();
            cls.Delete(sqlstmt);
            ShowMessageBox();
        }
        private void ShowMessageBox()
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "agree = confirm('Record Deleted...'); \n";
            sJavaScript += "if(agree)\n";
            sJavaScript += "window.location = \"Fees.aspx\";\n";
            sJavaScript += "</script>";
            Response.Write(sJavaScript);
        }
    }
}