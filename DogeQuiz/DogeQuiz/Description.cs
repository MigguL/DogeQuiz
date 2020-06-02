
using System.IO;

namespace DogeQuiz
{
    class Description
    {      /// <summary>
           /// Getting information about dogs from text file and passing them to app
           /// </summary>
        public string FileText { get; set; }
        public void ReadFile(string dPath)
        {
            FileText = File.ReadAllText(dPath);
        }
    }
}
