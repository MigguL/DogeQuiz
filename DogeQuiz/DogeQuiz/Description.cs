using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DogeQuiz
{
    class Description
    {
        public string FileText { get; set; }
        public void ReadFile(string dPath)
        {
            FileText = File.ReadAllText(dPath);
        }
    }
}
