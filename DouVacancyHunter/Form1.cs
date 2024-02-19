using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DouVacancyHunter
{
    public partial class Form1 : Form
    {
        JobPageFinder _jobPage;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _jobPage = new JobPageFinder("https://jobs.dou.ua/", ".NET", "< 1 року");

            _jobPage.Navigate();
        }
    }
}
