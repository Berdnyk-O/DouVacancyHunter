using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DouVacancyHunter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
        }
    }
}
