using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V106.IndexedDB;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Text;
using NUnit.Framework.Internal;
using System.Runtime.InteropServices;

namespace MetricaSolve
{
    public class Tests
    {
        IWebDriver driver;
        // List<WorkUpdate> workUpdate;
        bool login=false;
        public void loginCred()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://192.168.0.227:9090/Metrica/#/");
            Thread.Sleep(2000);

            IWebElement userid = driver.FindElement(By.Name("userid"));
            IWebElement pass = driver.FindElement(By.Name("password"));

            userid.SendKeys("asif.chowdhury");
            pass.SendKeys("AJ8WHU3Nspec");
            Thread.Sleep(2000);

            IWebElement ele1 = driver.FindElement(By.ClassName("btn-Signin"));

            ele1.Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//*[@id=\"collapseOne\"]/div/div/div/div/div/div/div[1]/b/a")).Click();
            //My TimeSheet button
            Thread.Sleep(3000);
            login= true;
            
        }



        public void Test1(WorkUpdate workUpdateList)
        {    
            

            if (login == false)
            {
                loginCred();
            }
            

            findDate(workUpdateList.Date);
            
            var drpdwn = driver.FindElement(By
                .XPath("//*[@id=\"handsontable\"]/div[1]/div[1]/div/div[1]/table/tbody/tr[1]/td[1]"));

            Thread.Sleep(3000);

            drpdwn.Click();
            drpdwn.Click();

            Thread.Sleep(2000);



            var projectContainer = driver.FindElement(By
            .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[1]/div[2]/textarea"));           

            projectContainer.SendKeys("SECL");
            projectContainer.SendKeys(Keys.Enter);



            var TaskTypedrpdwn = driver.FindElement(By
               .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[1]/div[1]/div[1]/div/div[1]/table/tbody/tr[1]/td[2]"));

            Thread.Sleep(3000);

            TaskTypedrpdwn.Click();
            TaskTypedrpdwn.Click();


            var taskContainer = driver
                .FindElement(By.XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[1]/div[3]/textarea"));

            taskContainer.SendKeys("Training");
            taskContainer.SendKeys(Keys.Enter);
            // container.SendKeys(Keys.ArrowDown);


            var TaskDescripDrpDwn = driver
                .FindElement(By
                .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[1]/div[1]/div[1]/div/div[1]/table/tbody/tr[1]/td[3]"));

            TaskDescripDrpDwn.Click();
            TaskDescripDrpDwn.Click();
            Thread.Sleep(200);

            var taskDescriptionContainer = driver
                .FindElement(By
                .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[1]/div[4]/textarea"));

            taskDescriptionContainer.SendKeys(workUpdateList.Work);
            taskDescriptionContainer.SendKeys(Keys.Enter);
            Thread.Sleep(3000);


            var FromDrpdwn = driver
            .FindElement(By
            .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[1]/div[1]/div[1]/div/div[1]/table/tbody/tr[1]/td[4]"));
            
            FromDrpdwn.Click();
            FromDrpdwn.Click();


            var FromTimeContainer = driver
                .FindElement(By
                .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[1]/div[4]/textarea"));

            FromTimeContainer.SendKeys(workUpdateList.firstTime);
            //FromDrpdwn.Click();
            TaskDescripDrpDwn.Click();
            Thread.Sleep(2000);
            //TaskDescripDrpDwn.Click();
            //TaskDescripDrpDwn.Click();


            var ToDrpDwn = driver
                .FindElement(By
                .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[1]/div[1]/div[1]/div/div[1]/table/tbody/tr[1]/td[5]"));

            ToDrpDwn.Click();
            ToDrpDwn.Click();

            

            var ToTimeContainer = driver
                .FindElement(By
                .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[1]/div[4]/textarea"));


            ToTimeContainer.SendKeys(workUpdateList.lastTime);
            ToTimeContainer.SendKeys(Keys.ArrowRight);
            Thread.Sleep(2000);

            var saveButton = driver
                .FindElement(By
                .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[2]/div[1]/button[2]"));
            saveButton.Click();
            Thread.Sleep(1000);

            var submitButton = driver
                .FindElement(By.
                XPath("/html/body/div[9]/div/div/div[3]/button[2]"));
            submitButton.Click();
            Thread.Sleep(1000);

            var todayButton = driver
                .FindElement(By
                .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[1]/button"));
            todayButton.Click();
            Thread.Sleep(1000);


            //driver.Close();

            
        }

    
        public void findDate(string prevDate)
        {
            DateTime targetDate=Convert.ToDateTime(prevDate);
            var today = DateTime.Now;

            //get difference of two dates
            var diffOfDates = today - targetDate;
            Console.WriteLine("Difference in Days: {0}", diffOfDates.Days);

            var backBtn = driver
                .FindElement(By
                .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[1]/span"));

            for(int x = diffOfDates.Days; x > 0; x--)
            {
                backBtn.Click();
                
                Thread.Sleep(1000);
                
            }


        }
        //[Test]
        //public void timeSplit()
        //{
        //    string text = "9:00 AM to 7:50 PM";

        //    DateTime firstDateTime = DateTime.Parse(text.Substring(0, 4));
        //    string firstTime = firstDateTime.ToString("HH:mm");
        //    Console.WriteLine("First time: " + firstTime);

        //    int startIndex = text.IndexOf(" to ") + 4;
        //    DateTime lastDateTime = DateTime.Parse(text.Substring(startIndex));
        //    string lastTime = lastDateTime.ToString("HH:mm");
        //    Console.WriteLine("Last time: "+ lastTime);

        //}

        [Test]

        public void fullRegex()
        {
            StringBuilder DatePattern = new StringBuilder(@"[A-z]+(ary|rch|ril|ay|ne|ly|st|ber)\s?\d{1,2}\s?(,|-)?\s?\d{4}");

            StringBuilder TimePattern = new StringBuilder(@"\d{1,2}:\d{1,2}\s?(AM|am|Am|PM|Pm|pm)\s?(to|To)\s?\d{1,2}:\d{1,2}\s?(AM|am|Am|PM|Pm|pm)\s?");

            StringBuilder WorkPattern = new StringBuilder(@"(\*[^*\n]+)");

            string FileLoc = "C:\\Users\\SECL\\Documents\\WorkUpdate.txt";

            string[] lines = File.ReadAllLines(FileLoc);



            WorkUpdate workObj;

            string? workDate = null;
            string? workUpdate = null;
            string? workTime = null;

            List<WorkUpdate> workUpdateList = new List<WorkUpdate>();

            for (int i = 0; i < lines.Length; i++)
            {

                if (Regex.IsMatch(lines[i], DatePattern.ToString()))
                {
                    workDate = Regex.Match(lines[i], DatePattern.ToString()).Value;
                    // Console.WriteLine(workDate);

                }

                else if (Regex.IsMatch(lines[i], WorkPattern.ToString()))
                {

                    workUpdate = workUpdate
                    + Regex.Match(lines[i], WorkPattern.ToString()).ToString();
                    //Console.WriteLine(workUpdate);

                }

                else if (Regex.IsMatch(lines[i], TimePattern.ToString()))
                {
                    workTime = Regex.Match(lines[i], TimePattern.ToString()).Value;
                    //Console.WriteLine(workTime);



                    DateTime firstDateTime = DateTime.Parse(workTime.Substring(0, 4));
                    string firstTime = firstDateTime.ToString("HH:mm");
                    //Console.WriteLine("First time: " + firstTime);

                    int startIndex = workTime.IndexOf(" to ") + 4;
                    DateTime lastDateTime = DateTime.Parse(workTime.Substring(startIndex));
                    string lastTime = lastDateTime.ToString("HH:mm");
                    //Console.WriteLine("Last time: " + lastTime);



                    workObj = new WorkUpdate(workDate, firstTime, lastTime, workUpdate);
                    workDate = null;
                    workTime = null;
                    workUpdate = null;
                    workUpdateList.Add(workObj);

                }



            }

                for(int i=0; i < workUpdateList.Count; i++)
                {
                    Test1(workUpdateList[i]);
                }
        }




       
        public class WorkUpdate
        {
            public string Date;
            public string firstTime;
            public string lastTime;
            public string Work;

            public WorkUpdate(string date, string firsttime, string lasttime, string work)
            {
                Date = date;
                firstTime = firsttime;
                lastTime = lasttime;
                Work = work;
            }
        }
    }
}
