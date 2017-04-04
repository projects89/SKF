using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SKF.Admin.MasterPages
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie reqCookies = Request.Cookies["userInfo"];
                if (reqCookies != null)
                {
                    lblUser.Text = reqCookies["UserName"].ToString();
                    lblHeaderUser.Text = reqCookies["UserName"].ToString();
                    lblUsr.Text = reqCookies["UserName"].ToString();
                    SetMenu();
                    //Response.Redirect("Index.aspx");
                }
                else
                {
                    lblUser.Text = "Gautam";
                    lblHeaderUser.Text = "Gautam";
                    lblUsr.Text = "Gautam";
                    //Response.Redirect("Login.aspx");
                }
            }
        }
        public void Logout()
        {
            HttpCookie _userInfoCookies = new HttpCookie("userInfo");
            //Adding Expire Time of cookies before existing cookies time
            _userInfoCookies.Expires = DateTime.Now.AddDays(-1);
            //Adding cookies to current web response
            Response.Cookies.Add(_userInfoCookies);
            Response.Redirect("Login.aspx");
        }
        public void SetMenu()
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                string userName = reqCookies["UserName"].ToString();
                string userType = reqCookies["UserType"].ToString();
                //imgProfile.Src = reqCookies["UserProfilePic"].ToString();

                if (userType == "Master_Admin")
                {
                    Master_Admin.Visible = true;
                    School_Admin.Visible = false;
                    School_Staff.Visible = false;
                    Student.Visible = false;
                    Parent.Visible = false;
                }
                else if (userType == "School_Admin")
                {
                    Master_Admin.Visible = false;
                    School_Admin.Visible = true;
                    School_Staff.Visible = false;
                    Student.Visible = false;
                    Parent.Visible = false;
                }
                else if (userType == "School_Staff")
                {
                    Master_Admin.Visible = false;
                    School_Admin.Visible = false;
                    School_Staff.Visible = true;
                    Student.Visible = false;
                    Parent.Visible = false;
                }
                else if (userType == "Student")
                {
                    Master_Admin.Visible = false;
                    School_Admin.Visible = false;
                    School_Staff.Visible = false;
                    Student.Visible = true;
                    Parent.Visible = false;
                }
                else if (userType == "Parent")
                {
                    Master_Admin.Visible = false;
                    School_Admin.Visible = false;
                    School_Staff.Visible = false;
                    Student.Visible = false;
                    Parent.Visible = true;
                }
                else
                {
                    Logout();
                }
            }
        }
    }
}