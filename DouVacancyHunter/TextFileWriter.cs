namespace DouVacancyHunter
{
    public class TextFileWriter : FileWriter
    {
        public string PathToFile {get; init; }

        public TextFileWriter(string pathToFile)
        {
            PathToFile = pathToFile;
            
        }

        public void Write(string text)
        {
            if (File.Exists(PathToFile))
            {
                File.Delete(PathToFile);
            }

            using StreamWriter sw = File.CreateText(PathToFile);
            sw.WriteLine(text);
        }
    }
}
