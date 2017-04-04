using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;

namespace SKF.Admin
{
    public partial class Forgot_Pass : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void btnForgotPass_Click(object sender, EventArgs e)
        {
            string userName = txtEmail.ToString().Trim();

            sqlstmt = "";
            sqlstmt = "Select * from login_master where login_uname = '"+ userName +"' ";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string RandomPass = CreateRandomPassword(8);
                SendMail Email = new SendMail();
                string Subject = "SKF - Reset Password";
                string MailTo = userName.ToString();
                string MessageBody = "Your Password Reset Successfully - " + RandomPass.ToString();
                string MailCC = "";
                string MailBCC = "gautamprojects89@gmail.com";

                //string MailBCC = "support@yogintechnologies.com";
                sqlstmt = "";
                sqlstmt = "Update login_master set login_password = '" + RandomPass.ToString() + "' where Login_uname = '" + userName.ToString() + "'";
                cls.Update(sqlstmt);
                Email.SendEmail(Subject, MessageBody, MailTo, MailCC, MailBCC);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Login", "alert('Password Sent to Your Email ID...')", true);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Login", "alert('Login Credential Invalid')", true);
            }
        }
        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
    }
}