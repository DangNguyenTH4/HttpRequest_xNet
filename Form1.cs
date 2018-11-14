using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace HTTP_Request_GetHowKteam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {

            //Crawl
            /*
             * HttpClient
             * HttpWebClient
             * HttpWebRequest
             * WebRequest
             * HttpRequest
             */
            string url = "https://www.howkteam.vn";
            var html = getData(url);
            testData(html);
        }
        void testData(string html)
        {
            File.WriteAllText("res.html", html);
            Process.Start("res.html");
        }
        string getData(string url,string cookie=null)
        {
            HttpRequest http = new HttpRequest();
            http.Cookies = new CookieDictionary();
            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }
            //http.UserAgent = "";
            string html = http.Get(url).ToString();
            return html;
        }
        void AddCookie(HttpRequest http,string cookie)
        {
            var temp = cookie.Split(';');
            foreach(var item in temp)
            {
                var temp2 = item.Split('=');
                if (temp2.Count() > 1)
                {
                    http.Cookies.Add(temp2[0], temp2[1]);
                }
            }
        }
       
        private void btnGetDataCookie_Click(object sender, EventArgs e)
        {
            string url = "https://www.howkteam.vn/";
            string cookie = "_ga=GA1.2.319522369.1539615594; _gid=GA1.2.1524716106.1542072362; ASP.NET_SessionId=znsibm2tpo0yougmclj1xcij; __RequestVerificationToken=rjZr3zvMR1Ov0lm6mw8SRgvBUDwJjqYguPlkd8IO_LdxVK_4qAPoaAGPEJytXu6WdvB3OzCsrDJhi_pKROgnMQRNgQ2qXQecGi6mhBheBHQ1; _gat=1; .AspNet.ApplicationCookie=kYhU6XznL0KQY9DPNIYNHZtCVUQ-Q-1-xfQQ_1UQ0osDD6UjXZE71axp2EmsqIbjvbz2-oIBhdP7KKxAPm0irCfiXSy9qCXMkHvslxJwthQIJuUAcWbXkBYb9Y3hSm8exyyJLviC0ck23vcsAdlMoYWqLvoSYla2Cw46dCLAwsBbv6JtBk_rCPOebFNYJWs15EQK2pC0WrlSfEwp1cIGTNu-OjyPVBj0QTzxzzCJ0u0y2jJsIEUL0_tqq8UPSEer10bXvViexQ8abwkHekhvf4Wh7KPen4yZjLO5B9JxkDUy_KXuUzeQiMvY_33n1VawsiuIPdtwQ59OFATa9e1ySd8s-bUKceSoAffRi1duPpxYEcLiOKkDm3KKJHBql3tGYpgj2vACyna9rBvgwvYJ30jm_0uJZDQXiEKZS40TK0hC4THjcYs__KQ4xzRK-LKIfzi5zggLh4fn_GVtgYMbuGEcL6ufP5Y10Qw8wWoeIREpMm08fvDIdJQF83dlU_nERY6NjMhTPTBqH-t6F8Ctxw";
            var html = getData(url,cookie);
            testData(html);
        }
    }

}
