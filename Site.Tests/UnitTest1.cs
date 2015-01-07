using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Protractor;
using OpenQA.Selenium;

namespace Site.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ChromeTest()
        {
            using (var driver = new ChromeDriver())
            {
                Execute(driver);
            }
        }

        [TestMethod]
        public void IETest()
        {
            using (var driver = new InternetExplorerDriver())
            {
                Execute(driver);
            }
        }

        private static void Execute(IWebDriver driver)
        {
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));

            var ngDriver = new NgWebDriver(driver, "html");

            var url = "http://www.angularjs.org";
            var task = "write a protractor test";

            var page = ngDriver.Url = url;

            var toDoInput = ngDriver.FindElement(NgBy.Input("todoText"));
            toDoInput.Clear();
            toDoInput.SendKeys(task);
            toDoInput.SendKeys("\n"); // Fake clicking add by adding enter

            var toDoList = ngDriver.FindElements(NgBy.Repeater("todo in todos"));
            Assert.AreEqual(3, toDoList.Count);
            Assert.AreEqual(task, toDoList[2].Text);
        }
    }
}
