
using System.IO;

namespace DogeQuiz
{
    class Description
    {   //Getting information about dogs from text file and passing them to app
        public string FileText { get; set; }
        public void ReadFile(string dPath)
        {
            FileText = File.ReadAllText(dPath);
        }
    }
}
