using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace DouVacancyHunter
{
    public class JobPageFinder
    {
        private readonly string _jobsPageUrl;
        private readonly string _technology;
        private readonly string _experience;

        private readonly ChromeDriver _driver;

        public JobPageFinder(string jobsPageUrl, string technologyName, string experience)
        {
            _jobsPageUrl = jobsPageUrl;
            _technology = technologyName;
            _experience = experience;

            _driver = new ChromeDriver();
        }
        
        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_jobsPageUrl);

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

            ReadOnlyCollection<IWebElement> experienceItems = experienceSelect.FindElements(By.XPath(".//*"));
            foreach (IWebElement experienceItem in experienceItems)
            {
                if (experienceItem.Text == _experience)
                {
                    experienceItem.Click();
                    break;
                }
            }
        }
    }
}
