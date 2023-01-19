using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V106.IndexedDB;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace MetricaSolve
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}
        IWebDriver driver;
        [Test]
        public void Test1()
        {    
            driver = new ChromeDriver();
            
            driver.Navigate().GoToUrl("http://192.168.0.227:9090/Metrica/#/");
            Thread.Sleep(2000);
           
            IWebElement userid = driver.FindElement(By.Name("userid"));            
            IWebElement pass = driver.FindElement(By.Name("password"));

            userid.SendKeys("mehedi.bhuiyan");
            pass.SendKeys("sadaf@1998");
            Thread.Sleep(2000);

            IWebElement ele1 = driver.FindElement(By.ClassName("btn-Signin"));

            ele1.Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//*[@id=\"collapseOne\"]/div/div/div/div/div/div/div[1]/b/a")).Click();

            Thread.Sleep(3000);

            findDate();


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

            taskDescriptionContainer.SendKeys("Test");
            taskDescriptionContainer.SendKeys(Keys.Enter);


            var FromDrpdwn = driver
            .FindElement(By
            .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[1]/div[1]/div[1]/div/div[1]/table/tbody/tr[1]/td[4]"));
            
            FromDrpdwn.Click();
            FromDrpdwn.Click();


            var FromTimeContainer = driver
                .FindElement(By
                .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[1]/div[4]/textarea"));

            FromTimeContainer.SendKeys("9:00");
            //FromDrpdwn.Click();
            TaskDescripDrpDwn.Click();
            Thread.Sleep(2000);
            TaskDescripDrpDwn.Click();
            TaskDescripDrpDwn.Click();


            var ToDrpDwn = driver
                .FindElement(By
                .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[1]/div[1]/div[1]/div/div[1]/table/tbody/tr[1]/td[5]"));

            ToDrpDwn.Click();
            ToDrpDwn.Click();

            

            var ToTimeContainer = driver
                .FindElement(By
                .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[2]/div/div[1]/div[4]/textarea"));


            ToTimeContainer.SendKeys("10:00");
            ToTimeContainer.SendKeys(Keys.ArrowRight);

            //driver.Close();

            Assert.Pass();
        }

    
        public void findDate()
        {
            var prevDate = new DateTime(2023, 1, 15); 
            var today = DateTime.Now;

            //get difference of two dates
            var diffOfDates = today - prevDate;
            Console.WriteLine("Difference in Days: {0}", diffOfDates.Days);

            var backBtn = driver
                .FindElement(By
                .XPath("/html/body/div[1]/aside[2]/section[2]/div[2]/div/div/div[1]/span"));

            for(int x = diffOfDates.Days; x > 0; x--)
            {
                backBtn.Click();
            }


        }
    }
}