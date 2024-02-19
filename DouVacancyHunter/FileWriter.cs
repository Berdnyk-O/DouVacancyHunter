namespace DouVacancyHunter
{
    public interface IFileWriter
    {
        string PathToFile { get; init; }

        public void Write(string text);
    }
}
