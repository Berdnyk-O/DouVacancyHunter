using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DouVacancyHunter
{
    public partial class Form1 : Form
    {
        VacancyHandler _jobPage;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _jobPage = new VacancyHandler("vacancies.txt", "https://jobs.dou.ua/", ".NET", "< 1 ����");

            _jobPage.Navigate();
            _jobPage.Process();
        }
    }
}
