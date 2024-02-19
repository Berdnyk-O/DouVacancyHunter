using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouVacancyHunter
{
    public interface FileWriter
    {
        string PathToFile { get; init; }

        public void Write(string text);
    }
}
