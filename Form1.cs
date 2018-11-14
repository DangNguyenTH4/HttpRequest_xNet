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
            HttpRequest http = new HttpRequest();
            string html = http.Get("https://www.howkteam.vn/").ToString();
            //MessageBox.Show(html);
            File.WriteAllText("res.html", html);
            Process.Start("res.html");

        }
    }
}
