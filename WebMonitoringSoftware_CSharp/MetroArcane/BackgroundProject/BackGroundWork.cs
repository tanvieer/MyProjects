using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;
using DbMethod;
using System.Net.NetworkInformation;

namespace BackgroundProject
{
    public class BackGroundWork
    {
        public static DbMethods dm = new DbMethods();

        public static bool IsConnectedToInternet()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static void Sendmail(String toemail, String subject, String body)
        {
            if (!IsConnectedToInternet())
            {
                return;
            }

            SaveData sv = new SaveData();
            SmtpSetting st = sv.LoadSMTP();

            string mailFrom = st.Email;
            string pass = st.Password;
            string smtpServer = st.SmtpServer;
            int port = st.Port;

            MailMessage mail = new MailMessage(mailFrom, toemail, subject, body);
            SmtpClient client = new SmtpClient(smtpServer);
            client.Port = port;
            client.Credentials = new System.Net.NetworkCredential(mailFrom, pass);
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
               // Console.WriteLine("mail sent");
            }
            catch 
            {
                //  Console.WriteLine("not sent");
                // show error message in system tray pop up message 
               
            }
        }


        [LogException]
        public static void Comparee(List<Tags> tag, string website, Websites wb)
        {
            if (!IsConnectedToInternet())
            {
                return;
            }
            WebClient web = new WebClient();
           
            String html = "404";
            try
            {
                html = web.DownloadString(website);
            }
            catch
            {
                SaveData sv = new SaveData();
                sv.UpdateStatus(wb.Id, 3);

                Thread t = new Thread(() => BackgroundProject.BackGroundWork.Sendmail(wb.MailTo, "Web Hack Informer Testing", "Error 404\n" + website + " Not Found!"));
                t.Start();

                return;
            }


            foreach (Tags t in tag)
            {
                MatchCollection str = Regex.Matches(html, "<" + t.TagName.ToString() + @"\s*(.+?)\s*>",RegexOptions.Singleline);

                bool thikase = false;
                foreach (Match m in str)
                {
                    string s = m.Groups[1].Value;
                    if (s.IndexOf(t.AttributeName.ToString() + "=\"" + t.AttributeValue.ToString() + "\"") >= 0)
                    {
                        thikase = true;
                        break; //changed. testing.
                    }
                }

                if (thikase)
                {
                    SaveData sv = new SaveData();
                    sv.UpdateStatus(wb.Id, false);
                    sv.UpdateDateTime(wb.Id);
                }
                else
                {
                    SaveData sv = new SaveData();
                    sv.UpdateStatus(wb.Id, true);
                    sv.UpdateDateTime(wb.Id);
                    Thread t2 = new Thread(() => BackgroundProject.BackGroundWork.Sendmail(wb.MailTo, "Web Hack Informer Testing", t.AttributeName.ToString() + "=\"" + t.AttributeValue.ToString() + "\"    Not Found in " + wb.Name.ToString()));
                    t2.Start();

                   // Sendmail(wb.MailTo, "Web Hack Informer Testing", t.AttributeName.ToString() + "=\"" + t.AttributeValue.ToString() + "\"    Not Found in " + wb.Name.ToString());
                                       
                    break;                    
                }
            }
        }

        public static void StartWork()
        {
            {
                SaveData sv = new SaveData();
                List<Websites> ab = sv.GetWebList();

                foreach (Websites a in ab)
                {

                    DateTime NextCheckTime = sv.GetNextCheckAt(a.Id);
                    DateTime CurrentTime = DateTime.Now;
                    int result = DateTime.Compare(CurrentTime, NextCheckTime);                    
                    
                    if (result < 0)
                        continue;
                    else
                    {
                        List<Tags> t = sv.GetTagList(a.Id);
                        if (t.Count!=0)
                        {
                            Thread cmp = new Thread(() => BackgroundProject.BackGroundWork.Comparee(t, SaveData.addHttp(a.Name.ToString()), a));
                            cmp.Start();
                           // Comparee(t, SaveData.addHttp(a.Name.ToString()), a);
                        }
                        else
                        {
                            sv.UpdateStatus(a.Id, 2);
                        }
                    }     

                    //List<Tags> t = sv.GetTagList(a.Id);

                    //Comparee(t, a.Name.ToString(), a);
                }
            }
        }

        public static void Run()
        {
            if (IsConnectedToInternet())
            {
                Thread th = new Thread(StartWork);
                th.Start();
                
                // StartWork();
            }  
        }
    }
}
