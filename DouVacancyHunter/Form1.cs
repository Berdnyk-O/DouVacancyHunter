namespace DouVacancyHunter
{
    public partial class Form1 : Form
    {
        private VacancyHandler _jobPage = null!;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            SetStatus("������� ����� �� ������� �������");

            _jobPage = new VacancyHandler("vacancies.txt", "https://jobs.dou.ua/", ".NET", "< 1 ����");
            _jobPage.Navigate();
            _jobPage.Process();
            _jobPage.Close();

            SetStatus("������� �����������");
        }

        private void SetStatus(string text)
        {
            if (Controls["StatusLabel"] is Label StatusLabel)
            {
                StatusLabel.Text = text;
            }
        }

       
    }
}
