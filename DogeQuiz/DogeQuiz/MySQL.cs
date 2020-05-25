using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows;

namespace DogeQuiz
{
    class MySQL
    {
        public static int GetQuestionsCount()
        {
            int QuestionsCount = 0;
            using (WebClient wc = new WebClient())
            {
                string QuestionsCountJSON = wc.DownloadString("https://swiktor.rzeszow.pl/WSIiZ/DogeQuiz/PHPs/GetQuestionsCount.php");
                var obj = new JavaScriptSerializer().Deserialize<dynamic>(QuestionsCountJSON);
                QuestionsCount = int.Parse(obj["QuestionsCount"]);
            }
            return QuestionsCount;
        }

        public static string GetQuestion(int numberOfQuestion)
        {
            string Question = "";
            using (WebClient wc = new WebClient())
            {
                string QuestionJSON = wc.DownloadString("https://swiktor.rzeszow.pl/WSIiZ/DogeQuiz/PHPs/GetQuestion.php?question=" + numberOfQuestion);
                var obj = new JavaScriptSerializer().Deserialize<dynamic>(QuestionJSON);
                Question = obj["question"];
            }
            return Question;
        }
        public static string GetCorrectAnswer(int numberOfQuestion)
        {
            string CorrectAnswers = "";
            using (WebClient wc = new WebClient())
            {
                string CorrectAnswersJSON = wc.DownloadString("https://swiktor.rzeszow.pl/WSIiZ/DogeQuiz/PHPs/GetCorrectAnswer.php?question=" + numberOfQuestion);
                var obj = new JavaScriptSerializer().Deserialize<dynamic>(CorrectAnswersJSON);
                CorrectAnswers = obj["CorrectAnswer"];
            }
            return CorrectAnswers;
        }

        public static List<string> GetAnswers(int numberOfQuestion)
        {
            List<string> answers = new List<string>();
            using (WebClient wc = new WebClient())
            {
                string AnswersJSON = wc.DownloadString("https://swiktor.rzeszow.pl/WSIiZ/DogeQuiz/PHPs/GetAnswers.php?question=" + numberOfQuestion);
                var objects = JsonConvert.DeserializeObject<List<object>>(AnswersJSON);
                var result = objects.Select(obj => JsonConvert.SerializeObject(obj)).ToArray();

                foreach (var Answer in result)
                {
                    var obj = new JavaScriptSerializer().Deserialize<dynamic>(Answer);
                    answers.Add(obj["Answers"]);
                }
            }
            return answers;
        }
    }
}

