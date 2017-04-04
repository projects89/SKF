using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Relations : System.Web.UI.Page
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

        public void GetData()
        {
            var unique_id = ViewState["Id"].ToString();
            if (unique_id != null)
            {
                sqlstmt = "";
                sqlstmt = "Select * from relation_trans where relation_id =" + unique_id.ToString();
                DataSet ds = cls.Select(sqlstmt);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtRelationsName.Text = ds.Tables[0].Rows[0]["relation_name"].ToString();
                }
            }

        }

        public void BindData()
        {
            sqlstmt = "";
            sqlstmt = "Select * from relation_trans";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Lst_Relations.DataSource = ds.Tables[0];
                Lst_Relations.DataBind();
            }
            else
            {
                Lst_Relations.DataSource = null;
            }
        }

        public void CrudOP()
        {
            //var unique_id = ViewState["Id"].ToString();
            if (ViewState["Id"] == null)
            {
                sqlstmt = "";
                sqlstmt = "Insert into relation_trans (relation_name) values ('" + txtRelationsName.Text.Trim() + "')";
                cls.Insert(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Inserted..!')", true);
                Response.Redirect("Relations.aspx");
                //ShowMessageBox("Activities.aspx","Record Inserted..!");    
            }
            else
            {
                sqlstmt = "";
                sqlstmt = "Update relation_trans set relation_name = '" + txtRelationsName.Text.Trim() + "' where relation_id=" + ViewState["Id"].ToString();
                cls.Update(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Updated..!')", true);
                Response.Redirect("Relations.aspx");
                //ShowMessageBox("Activities.aspx", "Record Updated..!");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CrudOP();
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            ViewState["Id"] = lnk.CommandArgument.ToString();
            GetData();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            ViewState["Id"] = lnk.CommandArgument.ToString();
            sqlstmt = "";
            sqlstmt = "Delete from relation_trans where relation_id=" + ViewState["Id"].ToString();
            cls.Delete(sqlstmt);
            ShowMessageBox();
        }
        private void ShowMessageBox()
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "agree = confirm('Record Deleted...'); \n";
            sJavaScript += "if(agree)\n";
            sJavaScript += "window.location = \"Relations.aspx\";\n";
            sJavaScript += "</script>";
            Response.Write(sJavaScript);
        }
    }
}