using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SKF
{
    public partial class Test_Date : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DateTime myDate = new DateTime();
                lblDate.Text = DateTime.Now.ToString();
            }
        }
    }
}