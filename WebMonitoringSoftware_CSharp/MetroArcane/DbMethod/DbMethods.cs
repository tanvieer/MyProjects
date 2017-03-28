using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Net.NetworkInformation;
namespace DbMethod
{
    public class DbMethods
    {
        bool invalid = false;
        public bool IsConnectedToInternet()
        {
            string host = "http://www.google.com";
            bool result = false;
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { }
            return result;
        }

        public bool IsValidEmail(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

        }
        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }





        private bool insertValidation(string url , string mailTo )
        {
            if (url == "" || mailTo == "")
            {
                return false;
            }
            using (DemoModelEntitiesDataContext db = new DemoModelEntitiesDataContext())
            {
                var results = (db.Websites.SingleOrDefault(x => x.Name == url));
                if (results == null)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AddWebsite(string url, string mailTo , string days , string hours)
        {
            int interval = convertCheckInterval(days, hours);
            using (DemoModelEntitiesDataContext db = new DemoModelEntitiesDataContext())
            {
                if (insertValidation(url , mailTo) && interval!=-1)
                {
                    Website web = new Website
                    {
                        Name = url,
                        MailTo = mailTo,
                        CheckInterval = interval
                    };
                    db.Websites.InsertOnSubmit(web);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool CheckLogin(string p)
        {
            string password;
            using (DemoModelEntitiesDataContext context = new DemoModelEntitiesDataContext())
            {
                var temp = (context.LoginInfos.SingleOrDefault(x => x.Id >= 0));
                password = temp.Password.ToString();
            }
            if (p == EncryptionDecryption.EncryptDecrypt.Decrypt( password ))
            {
                return true;
            }
            return false;
        }

        public string ForgotPasswordMail()
        {
            string mail = "";
            using (DemoModelEntitiesDataContext context = new DemoModelEntitiesDataContext())
            {
                LoginInfo temp = (context.LoginInfos.SingleOrDefault(x => x.Id >= 0));
                mail = temp.Email.ToString();
            }
            return mail;
        }

        public string ForgotPassword()
        {
            string pass = "";
            using (DemoModelEntitiesDataContext context = new DemoModelEntitiesDataContext())
            {
                LoginInfo temp = (context.LoginInfos.SingleOrDefault(x => x.Id >= 0));
                pass = EncryptionDecryption.EncryptDecrypt.Decrypt(temp.Password.ToString());
            }
            return pass;
        }

        public List<Website> LoadGridData()
        {
            using (DemoModelEntitiesDataContext context = new DemoModelEntitiesDataContext())
            {
                return context.Websites.ToList();
                //List<WebsiteDemoDatasource> wd = new List<WebsiteDemoDatasource>();
                
                //var result = from web in context.Websites
                //             select new
                //             {
                //                 web.Name,
                //                 web.MailTo,
                //                 web.Status,
                //                 web.LastCheckedAt,
                //                 web.NextCheckAt
                //             };
                // foreach ( var w in result)
                //{
                //    WebsiteDemoDatasource wd1 = new WebsiteDemoDatasource();
                //    wd1.Name = w.Name;
                //    wd1.MailTo = w.MailTo;
                //    wd1.Status = w.Status;
                //    wd1.LastCheckedAt = w.LastCheckedAt.ToString();
                //    wd1.NextCheckAt = w.NextCheckAt.ToString();

                //    wd.Add(wd1);

                //}

                //return wd;
                       // return result.Cast<WebsiteDemoDatasource>().ToList();
            }
        }

        public void RemoveWebsite(string s)
        {
            using (var context = new DemoModelEntitiesDataContext())
            {
                Website web = (context.Websites.SingleOrDefault(x => x.Name == s));
                var tags = context.Tags.Where(x => x.WebsiteID == web.Id);
                Website temp = context.Websites.SingleOrDefault(x => x.Id == web.Id);

                foreach (Tag t in tags)
                {
                    context.Tags.DeleteOnSubmit(t);
                }
                context.Websites.DeleteOnSubmit(temp);
                context.SubmitChanges();

            }
        }

        public SmtpSetting LoadSMTP()   // unused , same method used from SaveData Class 
        {
            using (var db = new DemoModelEntitiesDataContext())
            {

                using (DemoModelEntitiesDataContext dbd = new DemoModelEntitiesDataContext())
                {
                    SmtpSetting smtp = dbd.SmtpSettings.SingleOrDefault(x => x.id ==1);
                    return smtp;
                }
            }
        }

        public int GetWebId(string websiteName)
        {
            int id = -1;
            using (DemoModelEntitiesDataContext context = new DemoModelEntitiesDataContext())
            {
                Website temp = (context.Websites.FirstOrDefault(x => x.Name == websiteName));
                id = temp.Id;
            }
            return id;
        }

        public void Registration(string email, string pw)
        {

            using (DemoModelEntitiesDataContext db = new DemoModelEntitiesDataContext())
            {
                
                LoginInfo l = new LoginInfo
                {
                    Id=1,
                    Email = email,
                    Password = EncryptionDecryption.EncryptDecrypt.Encrypt(pw)
                };
                db.LoginInfos.InsertOnSubmit(l);
                db.SubmitChanges();
                
            }
        }

        public static bool CheckRegistration()
        {
            using (var db = new DemoModelEntitiesDataContext())
            {

                using (DemoModelEntitiesDataContext dbd = new DemoModelEntitiesDataContext())
                {
                    LoginInfo l = dbd.LoginInfos.SingleOrDefault(x => x.Id == 1);
                    if (l == null) return true;

                    return false;
                }
            }
        }

        public static int convertCheckInterval(string day, string hour)
        {
            int interval;
            day.Trim();
            hour.Trim();

            try
            {
                interval = Convert.ToInt32(day)*24 + Convert.ToInt32(hour);
                return interval;
            }
            catch
            {
                return -1;
            }
        }

        public static string addHttp(string url)
        {
            url.Trim();
            if(url.IndexOf("http://")==0 || url.IndexOf("https://")==0)
                return "http://"+url;
            return url;
        }

    }

}
