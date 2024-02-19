using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Text;

namespace DouVacancyHunter
{
    public class VacancyHandler : JobPageFinder
    {
        private FileWriter _writer;

        public VacancyHandler(string pathToFile, string jobsPageUrl, string technologyName, string experience)
            : base(jobsPageUrl, technologyName, experience)
        {
            _writer = new TextFileWriter(pathToFile);
        }

        public void Process()
        {
            StringBuilder data = new(50);

            var vacancies = FindVacancyListElement();

            foreach (var vacancy in vacancies)
            {
                data.Append(GetVacancyDate(vacancy));
                data.Append('\t');
                data.Append(GetVacancyName(vacancy));
                data.Append('\t');
                data.Append(GetVacancySalary(vacancy));
                data.Append('\t');
                data.Append(GetVacancyCiti(vacancy));
                data.Append('\n');
                data.Append(GetVacancyDescription(vacancy));
                data.Append("\n\n");

                _writer.Write(data.ToString());
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
            return vacancy.FindElement(By.ClassName("cities")).Text;
        }

        private string GetVacancyDescription(IWebElement vacancy) 
        {
            return vacancy.FindElement(By.ClassName("sh-info")).Text;
        }
    }
}
