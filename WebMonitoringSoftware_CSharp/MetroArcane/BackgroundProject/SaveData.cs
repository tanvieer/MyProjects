using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundProject
{
    class SaveData
    {
        public List<Websites> GetWebList()
        {
            SqlDbDataAccess da = new SqlDbDataAccess();
            SqlCommand cmd = da.GetCommand("SELECT * from Websites");

            List<Websites> weblist = GetWebsiteData(cmd);
            return weblist;
        }

        public List<Tags> GetTagList(int webid)
        {
            SqlDbDataAccess da = new SqlDbDataAccess();
            SqlCommand cmd = da.GetCommand(@"SELECT * from Tags Where WebsiteID = " + "'" + webid + "'");

            List<Tags> taglist = GetTags(cmd);
            return taglist;
        }


        private List<Websites> GetWebsiteData(SqlCommand cmd)
        {


            cmd.Connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Websites> list = new List<Websites>();

            using (reader)
            {
                while (reader.Read())
                {
                    Websites obj = new Websites();
                    obj.Id = reader.GetInt32(0);
                    obj.Name = reader.GetString(1).ToString();
                    obj.MailTo = reader.GetString(2).ToString();
                    
                    try
                    {
                        obj.Status = reader.GetString(3).ToString();
                        obj.LastCheckedAt = reader.GetDateTime(4);
                    }
                    catch
                    {

                    }
                    
                    list.Add(obj);
                }
                reader.Close();
            }
            cmd.Connection.Close();

            return list;
        }

        private List<Tags> GetTags(SqlCommand cmd)
        {


            cmd.Connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Tags> list = new List<Tags>();

            using (reader)
            {

                while (reader.Read())
                {
                    Tags obj = new Tags();
                    obj.WebsiteID = reader.GetInt32(0);
                    obj.TagName = reader.GetString(1).ToString();
                    obj.AttributeName = reader.GetString(2).ToString();
                    obj.AttributeValue = reader.GetString(3).ToString();
                    list.Add(obj);
                }
                reader.Close();
            }
            cmd.Connection.Close();

            return list;
        }

        public SmtpSetting LoadSMTP()
        {
            SqlDbDataAccess da = new SqlDbDataAccess();
            SqlCommand cmd = da.GetCommand(@"SELECT * from SmtpSettings Where id = '1'");

            SmtpSetting smtp = GetSmtp(cmd);
            return smtp;
        }


        private SmtpSetting GetSmtp(SqlCommand cmd)   
        {
            cmd.Connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            SmtpSetting obj = new SmtpSetting();

            using (reader)
            {

                reader.Read();
                {
                    
                    obj.Email = reader.GetString(0);
                    obj.Password = EncryptionDecryption.EncryptDecrypt.Decrypt(reader.GetString(1).ToString());
                    obj.SmtpServer = reader.GetString(2).ToString();
                    obj.Port = reader.GetInt32(3);
                }
                reader.Close();
            }
            cmd.Connection.Close();

            return obj;
        }

        public void UpdateStatus(int id , bool hacked)
        {
            using (BackgroundDBDataContext db = new BackgroundDBDataContext())
            {
                if (hacked)
                {
                    Website web = (db.Websites.SingleOrDefault(x => x.Id == id));
                    web.Status = "Compromised";
                    db.SubmitChanges();
                }
                else
                {
                    Website web = (db.Websites.SingleOrDefault(x => x.Id == id));
                    web.Status = "OK";
                    db.SubmitChanges();
                }

            }
        }
        public void UpdateStatus(int id, int hacked)
        {
            using (BackgroundDBDataContext db = new BackgroundDBDataContext())
            {
                Website web = (db.Websites.SingleOrDefault(x => x.Id == id));
                if (hacked==0)
                {
                    web.Status = "Compromised";
                }
                else if(hacked==1)
                {
                    web.Status = "OK";
                }
                else if(hacked==2)
                {
                    web.Status = "Tag N/A at LastCheck";
                }
                else if (hacked == 3)
                {
                    web.Status = "Url N/A";
                }
                db.SubmitChanges();

            }
        }
        public void UpdateDateTime(int id)
        {
            using (BackgroundDBDataContext db = new BackgroundDBDataContext())
            {
                Website web = (db.Websites.SingleOrDefault(x => x.Id == id));
                DateTime currentTime = new DateTime();
                currentTime = DateTime.Now;
                web.LastCheckedAt = currentTime;
                web.NextCheckAt = currentTime.AddHours(web.CheckInterval);
                db.SubmitChanges();
            }
        }

        public DateTime GetNextCheckAt(int id)
        {
            using (BackgroundDBDataContext db = new BackgroundDBDataContext())
            {
                Website web = (db.Websites.SingleOrDefault(x => x.Id == id));
                if (web.NextCheckAt != null)
                    return (DateTime)web.NextCheckAt;
                else
                    return DateTime.Now;
            }
        }

        public static string addHttp(string url)
        {
            url.Trim();
            if (url.IndexOf("http://") == 0 || url.IndexOf("https://") == 0)   
                return url;
            return "http://" + url;
        }
    }
}
