using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MetricaSolve
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void Test1()
        {    
            IWebDriver driver = new ChromeDriver();
            
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
            driver.FindElement(By.XPath("//*[@id=\"handsontable\"]/div[1]/div[1]/div/div[1]/table/tbody/tr[1]/td[1]")).SendKeys("SECL");
            //driver.Close();

            Assert.Pass();
        }
    }
}