using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net.Mail;
using System.IO;
using System.Net;

namespace SKF
{
    public class SendMail
    {
        private bool _UseCredintials = true;
        public bool SendEmail(string strSubject, string strMessageBody, string strMailto, string strMailCC, string strMailBCC)
        {
            try
            {
                MailMessage Message = new MailMessage();
                Message.IsBodyHtml = true;
                Message.Subject = strSubject;
                Message.From = new MailAddress(webConfigSettings.SMTPEmailFrom.ToString().Trim(), "HMS - Forgot Password");
                //Message.To.Add(new MailAddress(clsWebConfig.SMTPEmailTo.ToString().Trim()));

                if (Convert.ToString(strMailto).Trim() != string.Empty)
                {
                    string[] sToList = Convert.ToString(strMailto).Trim().Split(';');
                    foreach (string sTo in sToList)
                    { Message.To.Add(sTo.ToString().Trim()); }
                }

                if (Convert.ToString(strMailCC).Trim() != string.Empty)
                {
                    string[] sCCList = Convert.ToString(strMailCC).Trim().Split(';');
                    foreach (string sCC in sCCList)
                    { Message.CC.Add(sCC.ToString().Trim()); }
                }
                if (Convert.ToString(strMailBCC).Trim() != string.Empty)
                {
                    string[] sBCCList = Convert.ToString(strMailBCC).Trim().Split(';');
                    foreach (string sBCC in sBCCList)
                    { Message.Bcc.Add(sBCC.ToString().Trim()); }
                }
                Message.Body = strMessageBody.Trim();

                //if (this.Attachment != null)
                //{ Message.Attachments.Add(this.Attachment); }

                SmtpClient sc = new SmtpClient();
                sc.Host = webConfigSettings.SMTPServer;
                sc.Port = Convert.ToInt32(webConfigSettings.SMTPPort);
                if (this._UseCredintials)
                {
                     NetworkCredential _NC = new NetworkCredential();
                    _NC.UserName = webConfigSettings.SMTPUser;
                    _NC.Password = webConfigSettings.SMTPPass;
                    //_NC.Domain = clsWebConfig.SMTPDomain;
                    sc.Credentials = _NC;
                }

                sc.Send(Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
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