using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Text;

namespace DouVacancyHunter
{
    public class VacancyHandler : JobPageFinder
    {
        private readonly IFileWriter _writer;

        public VacancyHandler(string pathToFile, string jobsPageUrl, string technologyName, string experience)
            : base(jobsPageUrl, technologyName, experience)
        {
            _writer = new TextFileWriter(pathToFile);
        }

        public void Process()
        {
            StringBuilder data = new(100);

            OpenList();
            var vacancies = FindVacancyListElement();

            foreach (var vacancy in vacancies)
            {
                data.Append(GetVacancyDate(vacancy).PadRight(20));
                data.Append(GetVacancyName(vacancy).PadRight(50));
                data.Append(GetVacancySalary(vacancy).PadRight(30));
                data.Append(GetVacancyCiti(vacancy));
                data.Append('\n');
                data.Append(GetVacancyDescription(vacancy));
                data.Append("\n\n");
            }

            _writer.Write(data.ToString());
        }

        private void OpenList()
        {
            try
            {
                IWebElement? moreButton = _driver.FindElement(By.ClassName("more-btn"));
                moreButton?.FindElement(By.XPath(".//*")).Click();
                Thread.Sleep(1000);
            }
            catch
            {
            }

        }

        private ReadOnlyCollection<IWebElement> FindVacancyListElement()
        {
            IWebElement vacanciesUl = _driver.FindElement(By.ClassName("lt"));
            return vacanciesUl.FindElements(By.TagName("li"));
        }

        private string GetVacancyDate(IWebElement vacancy)
        {
            return vacancy.FindElement(By.ClassName("date")).Text;
        }

        private string GetVacancyName(IWebElement vacancy)
        {
            return vacancy.FindElement(By.ClassName("vt")).Text;
        }

        private string GetVacancySalary(IWebElement vacancy)
        {
            try
            {
                return vacancy.FindElement(By.ClassName("salary")).Text;
            }
            catch(NoSuchElementException)
            {
                return "заробітна плата не вказана";
            }
        }

        private string GetVacancyCiti(IWebElement vacancy)
        {
            try
            {
                return vacancy.FindElement(By.ClassName("cities")).Text;
            }
            catch (NoSuchElementException)
            {
                return "Місто не вказане";
            }
        }

        private string GetVacancyDescription(IWebElement vacancy) 
        {
            return vacancy.FindElement(By.ClassName("sh-info")).Text;
        }
    }
}
