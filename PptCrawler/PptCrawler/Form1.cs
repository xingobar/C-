using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
/*
* 
* 
* Reference :
* 
* 
* http://ms-net.blogspot.tw/2008/04/listview.html
* /// tutorial  http://toolsqa.com/selenium-c-sharp/
* https://www.nuget.org/packages/Selenium.WebDriver/
* http://stackoverflow.com/questions/32620309/how-to-get-an-attribute-value-from-a-href-link-in-selenium
* http://stackoverflow.com/questions/9951704/add-item-to-listview-control
* http://stackoverflow.com/questions/2309046/making-list-view-scroll-in-vertical-direction
* http://stackoverflow.com/questions/2309046/making-list-view-scroll-in-vertical-direction
* http://toolsqa.com/selenium-webdriver/choosing-effective-xpath/
* http://www.zendei.com/article/2475.html
*  http://stackoverflow.com/questions/24797485/how-to-download-image-from-url-using-c-sharp
*  https://msdn.microsoft.com/zh-tw/library/b873y76a(v=vs.110).aspx
*/

namespace PptCrawler
{
    public partial class Form1 : Form
    {
        String pattern = @"http://i.imgur.com/"; // 圖片正規化
        String path = @"./Images"; // 存放檔案的路徑
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void start_Click(object sender, EventArgs e)
        {
            DateTime dStart = DateTime.Now; // 取的現在時間
            start.Enabled = false;
            _continue.Enabled = false;
            int aTagCount = 0; //連結數
            int page = 0; // 頁數
            int count = 0; // 資料數
            Match m; // Match the regular expression pattern against a text string
            string url = "https://www.ptt.cc/bbs/Beauty/index2112.html";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);

            //// 建立資料夾
            try
            {
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);

                }
            }
            catch (Exception ex) {
                Console.WriteLine("[Error Message] : " + ex.Message );
            }



            /// listview vertical direction
            content.View = View.Details;
            ColumnHeader header = new ColumnHeader();
            header.Text = "";
            header.Name = "col1";
            content.Columns.Add(header);

            // create a new instance of the chrome driver
            IWebDriver driver = new ChromeDriver("webchrome.exe");
            
            // Launch the website
            driver.Navigate().GoToUrl(url);
            driver.Navigate().Refresh();
            
            // type : ReadOnlyCollection<IWebElement>
            var elements = driver.FindElements(By.XPath("//div[@class='title']/a"));
            aTagCount = elements.Count();
            for (int i = 0; i< aTagCount; i++)
            {
                elements = driver.FindElements(By.XPath("//div[@class='title']/a"));
                elements[i].Click();
                var aTagElements = driver.FindElements(By.XPath("//div[@id='main-content']/a"));
                foreach (var aTag in aTagElements)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    if (r.IsMatch(aTag.GetAttribute("href"))) {
                        listViewItem.Text = aTag.GetAttribute("href");
                        content.Items.Add(listViewItem);

                        /// download immage
                        using (WebClient client = new WebClient())
                        {
                            int index = aTag.GetAttribute("href").LastIndexOf("/");
                            // checking if image exist in path
                            if (!File.Exists(path + "/" + aTag.GetAttribute("href").Substring(index))) {
                                client.DownloadFile(new Uri(aTag.GetAttribute("href")), path + "/" + aTag.GetAttribute("href").Substring(index));
                                count++;
                            }
                        }

                    }
                }
                // 返回
                driver.Navigate().Back();
            }
            // 設定下載圖片個數
            image.Text = count.ToString();
            // Kill the browser
            driver.Close();
        }

        private void end_Click(object sender, EventArgs e)
        {
            // 離開程式
            Application.Exit();
        }
    }
}
