using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace DouVacancyHunter
{
    public class JobPageFinder
    {
        private string _jobsPageUrl;
        private string _technology;
        private string _experience;

        private IWebDriver _driver;

        public JobPageFinder(string jobsPageUrl, string technologyName, string experience)
        {
            _jobsPageUrl = jobsPageUrl;
            _technology = technologyName;
            _experience = experience;

            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_jobsPageUrl);
        }
        
        public void Navigate()
        {
            SelectTechtology();
            SelectExperience();
        }

        private void SelectTechtology()
        {
            IWebElement technologySelect = _driver.FindElement(By.Name("category"));
            technologySelect.SendKeys(_technology);
            Thread.Sleep(1000);
        }

        private void SelectExperience()
        {
            IWebElement filterRegion = _driver.FindElement(By.ClassName("b-region-filter"));
            IWebElement experienceSelect = filterRegion.FindElement(By.TagName("ul"));

            ReadOnlyCollection<IWebElement> childElements = experienceSelect.FindElements(By.XPath(".//*"));
            foreach (IWebElement child in childElements)
            {
                if (child.Text == _experience)
                {
                    child.Click();
                    break;
                }
            }
        }
    }
}
