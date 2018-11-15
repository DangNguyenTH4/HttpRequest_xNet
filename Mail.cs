using AE.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using xNet;

namespace HTTP_Request_GetHowKteam
{
    public static class Mail
    {
        public static void Verify(string email,string pass, string ipmap,int port)
        {
            string url = null;
            using (ImapClient ic = new ImapClient())
            {
                ic.Connect(ipmap, port, true, false);
                ic.Login(email, pass);
                ic.SelectMailbox("INBOX");
                int mailcount;
                for( mailcount = ic.GetMessageCount(); mailcount < 2; mailcount = ic.GetMessageCount())
                {
                    Mail.Delay(5);
                    ic.SelectMailbox("INBOX");
                }
                MailMessage[] mm = ic.GetMessages(mailcount - 1, mailcount - 1, false, false);
                MailMessage[] array = mm;
                for(int j = 0; j < array.Length; j++)
                {
                    MailMessage i = array[j];
                    bool flag = i.Subject == "Account regitration confimation" || i.Subject.Contains("Please verify your account");
                    if (flag)
                    {
                        string sbody = i.Body;
                        url = Regex.Match(i.Body, "a href=\"(https:[^\"]+)").Groups[1].Value;
                        bool flag2 = string.IsNullOrEmpty(url);
                        if (flag2)
                        {
                            url = Regex.Match(i.Body, "(http.*)").Groups[1].Value.Trim();
                            url = url.Substring(0, url.IndexOf('"'));
                        }
                        break;
                    }
                }
                ic.Dispose();
            }
            HttpRequest rq = new HttpRequest();
            rq.Cookies = new CookieDictionary(false);
            bool Load = false;
            while (!Load)
            {
                try
                {
                    rq.Get(url, null);
                    Load = true;
                }
                catch
                {

                }
            }
        }
        public static void Delay(int time)
        {
            for (int i = 0; i < time; i++)
            {
                Thread.Sleep(time);
            }
        }
    }
}
