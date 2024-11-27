﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Test
{
    [TestClass]
    public class AgeCategoryTest
    {
        [TestMethod]
        public void CreateAllergen()
        {
            #region Login
            IWebDriver driver = new ChromeDriver();
            Actions actions = new Actions(driver);
            driver.Navigate().GoToUrl("http://localhost:4200/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("email")).SendKeys("pali.david2001@gmail.com");
            System.Threading.Thread.Sleep(1 * 1000);
            driver.FindElement(By.Name("password")).SendKeys("string");
            System.Threading.Thread.Sleep(1 * 1000);
            //scroll down 
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            //wait 
            System.Threading.Thread.Sleep(1 * 1000);
            driver.FindElement(By.Id("login")).Click();
            System.Threading.Thread.Sleep(3 * 1000);
            #endregion

            #region Navigate and Add Allergen
            driver.Navigate().GoToUrl("http://localhost:4200/diet-group");
            System.Threading.Thread.Sleep(1 * 1000);
            driver.FindElement(By.XPath("/html/body/app-root/app-age-category/div/p-toolbar/div/div[1]/button[1]")).Click();
            System.Threading.Thread.Sleep(1 * 1000);
            driver.FindElement(By.Id("name")).SendKeys("test age category");
            System.Threading.Thread.Sleep(1 * 1000);
            driver.FindElement(By.Id("minAge")).SendKeys("10");
            System.Threading.Thread.Sleep(1 * 1000);
            driver.FindElement(By.Id("maxAge")).SendKeys("14");
            System.Threading.Thread.Sleep(1 * 1000);
            driver.FindElement(By.Id("maxDailyCalories")).SendKeys("1700");
            System.Threading.Thread.Sleep(1 * 1000);
            driver.FindElement(By.XPath("/html/body/app-root/app-age-category/p-dialog/div/div/div[4]/button[2]")).Click();
            System.Threading.Thread.Sleep(1 * 1000);
            #endregion

            #region Verify Allergen is Created
            driver.FindElement(By.XPath("//*[@id=\"pn_id_24\"]/div[1]/div/span/input")).SendKeys("test");
            System.Threading.Thread.Sleep(1 * 1000);
            actions.SendKeys(Keys.Enter).Perform();
            System.Threading.Thread.Sleep(1 * 1000);
            // search for the allergen in the grid and verify
            var isAllergenExists = driver.FindElement(By.XPath("//td[text()='test age category']")) is not null;
            Assert.IsTrue(isAllergenExists);
            driver.Quit();
            #endregion
        }

        [TestMethod]
        public void DeleteAllergen()
        {
            #region Login
            IWebDriver driver = new ChromeDriver();
            Actions actions = new Actions(driver);
            driver.Navigate().GoToUrl("http://localhost:4200/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("email")).SendKeys("pali.david2001@gmail.com");
            System.Threading.Thread.Sleep(1 * 1000);
            driver.FindElement(By.Name("password")).SendKeys("string");
            System.Threading.Thread.Sleep(1 * 1000);
            //scroll down 
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            //wait 
            System.Threading.Thread.Sleep(1 * 1000);
            driver.FindElement(By.Id("login")).Click();
            System.Threading.Thread.Sleep(3 * 1000);
            #endregion

            #region Navigate and Delete Allergen
            driver.Navigate().GoToUrl("http://localhost:4200/diet-group");
            System.Threading.Thread.Sleep(1 * 1000);
            driver.FindElement(By.XPath("//*[@id=\"pn_id_24\"]/div[1]/div/span/input")).SendKeys("test");
            System.Threading.Thread.Sleep(1 * 1000);
            actions.SendKeys(Keys.Enter).Perform();
            System.Threading.Thread.Sleep(1 * 1000);
            // search for the allergen in the grid and verify
            var allergenElement = driver.FindElement(By.XPath("//td[text()='test age category']"));
            var rowElement = allergenElement.FindElement(By.XPath(".."));
            rowElement.FindElement(By.XPath("//*[@id=\"delete\"]")).Click();
            System.Threading.Thread.Sleep(1 * 1000);
            driver.FindElement(By.XPath("/html/body/app-root/app-age-category/p-confirmdialog/div/div/div[3]/button[2]")).Click();
            System.Threading.Thread.Sleep(1 * 1000);
            // find the actionscolumn element
            #endregion

            #region Verify Allergen is Deleted
            driver.FindElement(By.XPath("//*[@id=\"pn_id_24\"]/div[1]/div/span/input")).SendKeys("test");
            System.Threading.Thread.Sleep(1 * 1000);
            actions.SendKeys(Keys.Enter).Perform();
            System.Threading.Thread.Sleep(1 * 1000);
            bool isAllergenExists;

            try
            {
                isAllergenExists = driver.FindElement(By.XPath("//td[text()='test allergen']")) is not null;
            }
            catch (NoSuchElementException)
            {
                isAllergenExists = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            Assert.IsTrue(!isAllergenExists);
            driver.Quit();
            #endregion
        }
    }
}
