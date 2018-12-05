using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBWebScrapper.IMDB
{
    public class IMDB
    {
        private IWebDriver WebDriver;
        public IMDB(IWebDriver driver)
        {
            this.WebDriver = driver;
            this.WebDriver.Url = @"https://www.imdb.com";
            this.WebDriver.Navigate();
        }

        public IMDB SearchByActorName(string actorName)
        {
            var queryBox = WebDriver.FindElement(By.Id("navbar-query"));
            queryBox.SendKeys(actorName);
            queryBox.SendKeys(Keys.Enter);
            return SelectActor(actorName);
        }

        public IMDB SelectActor(string actorName)
        {
            var actorlink = WebDriver.FindElement(By.LinkText(actorName));
            actorlink.Click();

            return this;
        }

        public void SaveMoviesDetails()
        {
          var infoLine = WebDriver.FindElement(By.Id("filmo-head-actor"));
            var subSection = WebDriver.FindElement(By.ClassName("filmo-category-section"));
            var moviesDivs = subSection.FindElements(By.ClassName("filmo-row "));
            foreach (var div in moviesDivs)
            {
                var year = div.FindElement(By.ClassName("year_column"))?.Text.Trim();
                var test = div.FindElement(By.XPath("//b//a"))?.Text.Trim();
            }
        }
    }
}
