using System.Collections.Specialized;
using System.Configuration;

namespace DouVacancyHunter
{
    public partial class Form1 : Form
    {
        private readonly NameValueCollection _appSettings;
        private VacancyHandler _jobPage = null!;

        public Form1()
        {
            _appSettings = ConfigurationManager.AppSettings;

            InitializeComponent();
            InitTextboxes();
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            if (ValidTextBoxes())
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
            else
            {
                SetStatus("Помилка з парсингом даних з текстових полів");
            }
        }

        private void SetStatus(string text)
        {
            if (Controls["StatusLabel"] is Label StatusLabel)
            {
                StatusLabel.Text = text;
            }
        }

        private bool ValidTextBoxes()
        {
            if (string.IsNullOrEmpty(PathTextBox.Text) || string.IsNullOrEmpty(TechnologyBox.Text)
                    || string.IsNullOrEmpty(ExperienceBox.Text))
            {
                return false;
            }

            return true;
        }

        private void InitTextboxes()
        {
            PathTextBox.Text = _appSettings["pathToFile"];
            TechnologyBox.Text = _appSettings["technology"];

            string[] expirienceValue = _appSettings["experiencesList"]!.Split(';');
            ExperienceBox.Items.AddRange(expirienceValue);
            ExperienceBox.SelectedIndex = 0;
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
    }
}
