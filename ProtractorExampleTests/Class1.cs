using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using Protractor;

namespace ProtractorExampleTests
{
    
    public class Class1
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var driver = new ChromeDriver();
            var ngDriver = new NgWebDriver(driver, "html");
            var url = "http://www.angularjs.org";
            var page = ngDriver.Url = url;

            var toDoInput = ngDriver.FindElement(NgBy.Binding("todoText"));
            toDoInput.Clear();
            toDoInput.SendKeys("write a protractor test");

        }
    }
}
