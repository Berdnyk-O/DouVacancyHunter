using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace DouVacancyHunter
{
    public class VacancyHandler : JobPageFinder
    {

        public VacancyHandler(string jobsPageUrl, string technologyName, string experience)
            : base(jobsPageUrl, technologyName, experience)
        {
        }

        public void Process()
        {
            string date;
            string name;
            string salary;
            string citi;
            string description;

            var vacancies = FindVacancyListElement();

            foreach (var vacancy in vacancies)
            {
                date = GetVacancyDate(vacancy);
                name = GetVacancyName(vacancy);
                salary = GetVacancySalary(vacancy);
                citi = GetVacancyCiti(vacancy);
                description = GetVacancyDescription(vacancy);
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
