using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        //Just Request
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
        string getData(string url, HttpRequest http = null, string userArgent = null, string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieDictionary();
            }
            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }
            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }
            string html = http.Get(url).ToString();
            return html;
        }

        void AddCookie(HttpRequest http, string cookie)
        {
            var temp = cookie.Split(';');
            foreach (var item in temp)
            {
                var temp2 = item.Split('=');
                if (temp2.Count() > 1)
                {
                    http.Cookies.Add(temp2[0], temp2[1]);
                }
            }
        }
        string url = "https://www.howkteam.vn/";
        string urlLogin = "https://www.howkteam.vn/account/login?returnUrl=https%3A%2F%2Fwww.howkteam.vn%2F";
        private void btnGetDataCookie_Click(object sender, EventArgs e)
        {
            string url = "https://www.howkteam.vn/";
            string cookie = "_ga=GA1.2.319522369.1539615594; _gid=GA1.2.1524716106.1542072362; ASP.NET_SessionId=znsibm2tpo0yougmclj1xcij; __RequestVerificationToken=rjZr3zvMR1Ov0lm6mw8SRgvBUDwJjqYguPlkd8IO_LdxVK_4qAPoaAGPEJytXu6WdvB3OzCsrDJhi_pKROgnMQRNgQ2qXQecGi6mhBheBHQ1; _gat=1; .AspNet.ApplicationCookie=kYhU6XznL0KQY9DPNIYNHZtCVUQ-Q-1-xfQQ_1UQ0osDD6UjXZE71axp2EmsqIbjvbz2-oIBhdP7KKxAPm0irCfiXSy9qCXMkHvslxJwthQIJuUAcWbXkBYb9Y3hSm8exyyJLviC0ck23vcsAdlMoYWqLvoSYla2Cw46dCLAwsBbv6JtBk_rCPOebFNYJWs15EQK2pC0WrlSfEwp1cIGTNu-OjyPVBj0QTzxzzCJ0u0y2jJsIEUL0_tqq8UPSEer10bXvViexQ8abwkHekhvf4Wh7KPen4yZjLO5B9JxkDUy_KXuUzeQiMvY_33n1VawsiuIPdtwQ59OFATa9e1ySd8s-bUKceSoAffRi1duPpxYEcLiOKkDm3KKJHBql3tGYpgj2vACyna9rBvgwvYJ30jm_0uJZDQXiEKZS40TK0hC4THjcYs__KQ4xzRK-LKIfzi5zggLh4fn_GVtgYMbuGEcL6ufP5Y10Qw8wWoeIREpMm08fvDIdJQF83dlU_nERY6NjMhTPTBqH-t6F8Ctxw";
            var html = getData(url);
            testData(html);
        }
        string GetLoginDataToken(string html)
        {
            string token = "";
            var res = Regex.Matches(html, @"(?<=__RequestVerificationToken"" type=""hidden"" value="").*?(?="")", RegexOptions.Singleline);
            if (res != null && res.Count > 0)
            {
                token = res[1].ToString();
            }
            return token;
        }
        string PostData(HttpRequest http, string url, string data = null, string contentType = null, string userArgent = null, string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieDictionary();
            }
            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }
            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }
            string html = http.Post(url, data, contentType).ToString();
            return html;
        }
        private void btnPostLogin_Click(object sender, EventArgs e)
        {
            HttpRequest http = new HttpRequest();
            http.Cookies = new CookieDictionary();
            string userArgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36";

            var html = getData(url, http, userArgent);

            string token = GetLoginDataToken(html);
            string userName = "dangnt520@wru.vn";
            string passWord = "nguyenthedang1109";
            string data = "__RequestVerificationToken=" + token + "&Email=" + WebUtility.UrlEncode(userName) + "&Password=" + WebUtility.UrlEncode(passWord) + "&RememberMe=true&RememberMe=false";
            html = http.Post(urlLogin, data, "application/json; charset=utf-8").ToString();

            File.WriteAllText("res.html", html);
            Process.Start("res.html");

        }


        /// <summary>
        /// Upload file:http://www.uploadfiles.io
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            UploadFile();
        }
        string UploadData(HttpRequest http, string url, MultipartContent data = null, string contentType = null, string userArgent = null, string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieDictionary();
            }
            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }
            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }
            string html = http.Post(url, data).ToString();
            return html;
        }
        void UploadFile(string filepath)
        {
            MultipartContent data = new MultipartContent() {
                {new StringContent("dzuuid"),"1ac01ba0-c711-44e9-92b1-4b1208e9a02f" },
                {new StringContent("dzchunkindex"),"0" },
                {new StringContent("dztotalfilesize"),"131190" },
                {new StringContent("dzchunksize"),"26143000" },
                {new StringContent("dztotalchunkcount"),"1" },
                {new StringContent("dzchunkbyteoffset"),"0" },
                {new FileContent(filepath),"file",Path.GetFileName(filepath)}
            };
            var html = UploadData(null, "https://up.uploadfiles.io/upload", data);


            var dataRes = JsonConvert.DeserializeObject<UploadFileModel>(html);

            Process.Start(dataRes.destination);
        }
        void UploadFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                UploadFile(dialog.FileName);
            }
        }


        /// <summary>
        /// 
        /// 
        /// CapchaNormal
        /// 
        /// 
        /// </summary>
        private string capchaKey = "*************************";
        private string urlRequestVtcCapchaImg = "https://vtcgame.vn//CaptchaImage.ashx?ss=0.014018362059772027&w=60&h=40";
        private string urlRequestTopupByCard = "https://vtcgame.vn/Vcoin/TopupByCard";
        private string urlVtcCoint = "https://vtcgame.vn/nap-vcoin/qua-the-cao.html";
        private void btnCapcha_Click(object sender, EventArgs e)
        {
            HttpRequest http = new HttpRequest();
            http.Cookies = new CookieDictionary();
            string userArgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36";

            var html = getData(urlVtcCoint, http, userArgent);

            string token = GetVtcToken(html);

            //File.WriteAllBytes("Capcha.jpg",http.Get(urlRequestVtcCapchaImg).ToMemoryStream().ToArray());
            var binImg = http.Get(urlRequestVtcCapchaImg).ToMemoryStream().ToArray();
            File.WriteAllBytes("Capcha.jpg", binImg);

            string userName = "rongk9";
            string serial = "123";
            string code = "123123";
            string capcha = ResloveNormalCapcha(capchaKey, Convert.ToBase64String(binImg));

            string data = "__RequestVerificationToken=" + token + "&typeCard=VC&seriCard=" + serial + "&codeCard=" + code + "&userNameReceive=" + userName + "&captcha=" + capcha + "&captchaVerify=";
            html = PostData(http, urlRequestTopupByCard, data, "application/x-www-form-urlencoded; charset=utf-8").ToString();

            VtcChargeResponseModel resData = JsonConvert.DeserializeObject<VtcChargeResponseModel>(html);
            MessageBox.Show(resData.ErorrMess);
        }
        string GetVtcToken(string html)
        {
            string token = "";
            var res = Regex.Matches(html, @"(?<=__RequestVerificationToken"" type=""hidden"" value="").*?(?="")", RegexOptions.Singleline);
            if (res != null && res.Count > 0)
            {
                token = res[0].ToString();
            }
            return token;
        }
        string ResloveNormalCapcha(string capChaKey,string imgBase64)
        {
            string cap = "";

            Recaptcha_2Captcha reCap = new Recaptcha_2Captcha(capchaKey);
            bool isSuccess = reCap.SolveNormalCapcha(imgBase64, out cap);
            while (!isSuccess)
            {
                isSuccess = reCap.SolveNormalCapcha(imgBase64, out cap);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            return cap;
        }

        private void btnRecaptcha_Click(object sender, EventArgs e)
        {

        }
    }

    public class UploadFileModel
    {
        public bool status { get; set; }
        public int id { get; set; }
        public string url { get; set; }
        public string destination { get; set; }
        public string name { get; set; }
        public string filename { get; set; }
        public string slug { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string expiry { get; set; }
        public string session_id { get; set; }
        public string timing { get; set; }
    }


    public class VtcChargeResponseModel
    {
        public int ResponseStatus { get; set; }
        public string ErorrMess { get; set; }
    }

}
