using System.Collections.Specialized;
using System.Configuration;

namespace DouVacancyHunter
{
    public partial class Form1 : Form
    {
        private NameValueCollection _appSettings;
        private VacancyHandler _jobPage = null!;
        public Form1()
        {
            _appSettings = ConfigurationManager.AppSettings;
            
            InitializeComponent();
            InitTextboxes();
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            SetStatus("Виконуєм пошук та парсинг сторінки");

            _jobPage = new VacancyHandler(
                GetPathTextBoxValue(),
                _appSettings["url"]!,
                GetTechnologyBoxValue(),
                GetExperienceBoxValue());

            _jobPage.Navigate();
            _jobPage.Process();
            _jobPage.Close();

            SetStatus("Сторінка опрацьована");
        }

        private void SetStatus(string text)
        {
            if (Controls["StatusLabel"] is Label StatusLabel)
            {
                StatusLabel.Text = text;
            }
        }

        private void InitTextboxes()
        {
            Controls["PathTextBox"]!.Text = _appSettings["pathToFile"];
            Controls["TechnologyBox"]!.Text = _appSettings["technology"];

            ComboBox expirienceBox = (ComboBox)Controls["ExperienceBox"]!;
            string[] expirienvveValue = _appSettings["experiencesList"]!.Split(';');
            expirienceBox.Items.AddRange(expirienvveValue);
            expirienceBox.SelectedIndex = 0;
        }
        private string GetPathTextBoxValue()
        {
            return Controls["PathTextBox"]!.Text;
        }

        private string GetTechnologyBoxValue()
        {
            return Controls["TechnologyBox"]!.Text;
        }

        private string GetExperienceBoxValue()
        {
            return Controls["ExperienceBox"]!.Text;
        }

        private void PathTextBox_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
