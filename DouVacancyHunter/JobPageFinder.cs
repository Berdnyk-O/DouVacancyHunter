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

        internal readonly IWebDriver _driver;

        public JobPageFinder(string jobsPageUrl, string technologyName, string experience)
        {
            _jobsPageUrl = jobsPageUrl;
            _technology = technologyName;
            _experience = experience;

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;

            ChromeOptions options = new();
            options.AddArgument("start-maximized");

            _driver = new ChromeDriver(chromeDriverService, options);

            //_driver = new ChromeDriver();
            //_driver.Manage().Window.Maximize();

            Thread.Sleep(1000);
        }
        
        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_jobsPageUrl);

            SelectTechnology();
            SelectExperience();

            Thread.Sleep(1000);
        }

        private void SelectTechnology()
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
                    experienceItem.FindElement(By.XPath(".//*")).Click();
                    break;
                }
            }
        }

        public void Close()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
