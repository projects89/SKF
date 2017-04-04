using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt= "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string unm = (string)(Session["username"]);
                HttpCookie reqCookies = Request.Cookies["userInfo"];
                if (reqCookies != null)
                {
                    LoginData();
                }
                else
                {
                    //Response.Redirect("Dashboard.aspx");
                    //Response.Redirect("Login.aspx");
                }
            }
        }
        void LoginData()
        {
            string ipaddress;
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
            {
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            string dt = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string user = txtEmail.Text.Trim();
            string pass = txtPassword.Text.Trim();
            sqlstmt = "";
            sqlstmt = "Select * from login_master where login_password = '" + pass.ToString() + "' AND login_uname = '" + user.ToString() + "' ";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                sqlstmt = "";
                sqlstmt = "Update login_master set login_datetime= '"+ dt +"', login_ip = '"+ ipaddress +"' where login_uname = '"+ user.ToString() +"' ";
                cls.Update(sqlstmt);

                int user_type_id = Convert.ToInt32(ds.Tables[0].Rows[0]["login_usertype"].ToString());
                string user_id = ds.Tables[0].Rows[0]["login_id"].ToString();

                sqlstmt = "";
                sqlstmt = "Select * from login_type_master where login_type_id = '" + user_type_id + "' ";
                DataSet dss = cls.Select(sqlstmt);

                string user_type = dss.Tables[0].Rows[0]["login_type_name"].ToString();

                if (user_type == "Master_Admin")
                {
                    sqlstmt = "";
                    sqlstmt = "Select * from admin_master where admin_username = '"+ user.ToString() +"' ";
                    DataSet dsss = cls.Select(sqlstmt);

                    string userName = dsss.Tables[0].Rows[0]["admin_fullname"].ToString();

                    //Creting a Cookie Object
                    HttpCookie _userInfoCookies = new HttpCookie("userInfo");

                    //Setting values inside it
                    _userInfoCookies["UserName"] = userName.ToString();
                    _userInfoCookies["UserID"] = user_id.ToString();
                    _userInfoCookies["UserType"] = user_type.ToString();
                    _userInfoCookies["Expire"] = "1 Days";

                    //Adding Expire Time of cookies
                    _userInfoCookies.Expires = DateTime.Now.AddDays(1);

                    //sqlstmt = "";
                    //sqlstmt = "Select * from admin_master where admin_id = " + User_ID.ToString();
                    //DataSet dsData = cls.Select(sqlstmt);
                    //if (dsData.Tables[0].Rows.Count > 0)
                    //{ _userInfoCookies["UserProfilePic"] = (Convert.ToString(dsData.Tables[0].Rows[0]["admin_img_thumb_path"]).Trim() != "" ? Convert.ToString(dsData.Tables[0].Rows[0]["admin_img_thumb_path"]).Trim() : "assets/images/pic.jpg"); }
                    //else
                    //{ _userInfoCookies["UserProfilePic"] = "assets/images/pic.jpg"; }

                    //Adding cookies to current web response
                    Response.Cookies.Add(_userInfoCookies);
                    Response.Redirect("Dashboard.aspx");
                }
                else if (user_type == "School_Admin")
                {
                    //Creting a Cookie Object
                    HttpCookie _userInfoCookies = new HttpCookie("userInfo");

                    //Setting values inside it
                    _userInfoCookies["UserName"] = user.ToString();
                    _userInfoCookies["UserID"] = user_id.ToString();
                    _userInfoCookies["UserType"] = user_type.ToString();
                    _userInfoCookies["Expire"] = "1 Days";

                    //Adding Expire Time of cookies
                    _userInfoCookies.Expires = DateTime.Now.AddDays(1);

                    //sqlstmt = "";
                    //sqlstmt = "Select * from admin_master where admin_id = " + User_ID.ToString();
                    //DataSet dsData = cls.Select(sqlstmt);
                    //if (dsData.Tables[0].Rows.Count > 0)
                    //{ _userInfoCookies["UserProfilePic"] = (Convert.ToString(dsData.Tables[0].Rows[0]["admin_img_thumb_path"]).Trim() != "" ? Convert.ToString(dsData.Tables[0].Rows[0]["admin_img_thumb_path"]).Trim() : "assets/images/pic.jpg"); }
                    //else
                    //{ _userInfoCookies["UserProfilePic"] = "assets/images/pic.jpg"; }

                    //Adding cookies to current web response
                    Response.Cookies.Add(_userInfoCookies);
                    Response.Redirect("Dashboard.aspx");
                }
                else if (user_type == "School_Staff")
                {
                    //Creting a Cookie Object
                    HttpCookie _userInfoCookies = new HttpCookie("userInfo");

                    //Setting values inside it
                    _userInfoCookies["UserName"] = user.ToString();
                    _userInfoCookies["UserID"] = user_id.ToString();
                    _userInfoCookies["UserType"] = user_type.ToString();
                    _userInfoCookies["Expire"] = "1 Days";

                    //Adding Expire Time of cookies
                    _userInfoCookies.Expires = DateTime.Now.AddDays(1);

                    //sqlstmt = "";
                    //sqlstmt = "Select * from admin_master where admin_id = " + User_ID.ToString();
                    //DataSet dsData = cls.Select(sqlstmt);
                    //if (dsData.Tables[0].Rows.Count > 0)
                    //{ _userInfoCookies["UserProfilePic"] = (Convert.ToString(dsData.Tables[0].Rows[0]["admin_img_thumb_path"]).Trim() != "" ? Convert.ToString(dsData.Tables[0].Rows[0]["admin_img_thumb_path"]).Trim() : "assets/images/pic.jpg"); }
                    //else
                    //{ _userInfoCookies["UserProfilePic"] = "assets/images/pic.jpg"; }

                    //Adding cookies to current web response
                    Response.Cookies.Add(_userInfoCookies);
                    Response.Redirect("Dashboard.aspx");
                }
                else if (user_type == "Student")
                {
                    //Creting a Cookie Object
                    HttpCookie _userInfoCookies = new HttpCookie("userInfo");

                    //Setting values inside it
                    _userInfoCookies["UserName"] = user.ToString();
                    _userInfoCookies["UserID"] = user_id.ToString();
                    _userInfoCookies["UserType"] = user_type.ToString();
                    _userInfoCookies["Expire"] = "1 Days";

                    //Adding Expire Time of cookies
                    _userInfoCookies.Expires = DateTime.Now.AddDays(1);

                    //sqlstmt = "";
                    //sqlstmt = "Select * from admin_master where admin_id = " + User_ID.ToString();
                    //DataSet dsData = cls.Select(sqlstmt);
                    //if (dsData.Tables[0].Rows.Count > 0)
                    //{ _userInfoCookies["UserProfilePic"] = (Convert.ToString(dsData.Tables[0].Rows[0]["admin_img_thumb_path"]).Trim() != "" ? Convert.ToString(dsData.Tables[0].Rows[0]["admin_img_thumb_path"]).Trim() : "assets/images/pic.jpg"); }
                    //else
                    //{ _userInfoCookies["UserProfilePic"] = "assets/images/pic.jpg"; }

                    //Adding cookies to current web response
                    Response.Cookies.Add(_userInfoCookies);
                    Response.Redirect("Dashboard.aspx");
                }
                else if (user_type == "Parent")
                {
                    //Creting a Cookie Object
                    HttpCookie _userInfoCookies = new HttpCookie("userInfo");

                    //Setting values inside it
                    _userInfoCookies["UserName"] = user.ToString();
                    _userInfoCookies["UserID"] = user_id.ToString();
                    _userInfoCookies["UserType"] = user_type.ToString();
                    _userInfoCookies["Expire"] = "1 Days";

                    //Adding Expire Time of cookies
                    _userInfoCookies.Expires = DateTime.Now.AddDays(1);

                    //sqlstmt = "";
                    //sqlstmt = "Select * from admin_master where admin_id = " + User_ID.ToString();
                    //DataSet dsData = cls.Select(sqlstmt);
                    //if (dsData.Tables[0].Rows.Count > 0)
                    //{ _userInfoCookies["UserProfilePic"] = (Convert.ToString(dsData.Tables[0].Rows[0]["admin_img_thumb_path"]).Trim() != "" ? Convert.ToString(dsData.Tables[0].Rows[0]["admin_img_thumb_path"]).Trim() : "assets/images/pic.jpg"); }
                    //else
                    //{ _userInfoCookies["UserProfilePic"] = "assets/images/pic.jpg"; }

                    //Adding cookies to current web response
                    Response.Cookies.Add(_userInfoCookies);
                    Response.Redirect("Dashboard.aspx");
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Login", "alert('Login Success')", true);

                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Login", "alert('Login Credentials Invalid')", true);
            }
        }
        protected void butLogin_Click(object sender, EventArgs e)
        {
            LoginData();
        }
    }
}