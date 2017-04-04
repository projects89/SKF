using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SKF.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //HttpCookie reqCookies = Request.Cookies["userInfo"];
                //if (reqCookies != null)
                //{
                //    string UsrID = reqCookies["UserID"].ToString();
                //}
            }

        }
    }
}