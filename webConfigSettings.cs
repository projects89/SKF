using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace SKF
{
    public class webConfigSettings
    {
        public static string SMTPPort
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["smtpPort"].ToString(); }
        }

        public static string SMTPServer
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["smtpServer"].ToString(); }
        }

        public static string SMTPUser
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["smtpUserName"].ToString(); }
        }

        public static string SMTPPass
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["smtpPassword"].ToString(); }
        }

        public static string SMTPDomain
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["smtpDomain"].ToString(); }
        }

        public static string SMTPEmailFrom
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["EmailFrom"].ToString(); }
        }

        public static string SMTPEmailTo
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["EmailTo"].ToString(); }
        }

        public static string SMTPEmailCC
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["EmailCC"].ToString(); }
        }
        public static string SMTPEmailBCC
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["EmailBCC"].ToString(); }
        }
    }
}