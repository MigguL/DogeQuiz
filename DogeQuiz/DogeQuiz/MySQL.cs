using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;

namespace DogeQuiz
{    /// <summary>
     /// Class supports MySQL
     /// </summary>
    public class MySQL
    {
        /// <summary>
        /// Method to get JSON data from server about questions countk
        /// </summary>
        /// <returns>
        /// Integer with count of questions on server
        /// </returns>
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

        /// <summary>
        /// Method to get JSON data from server about question base on question ID
        /// </summary>
        /// <param name="numberOfQuestion">Number of question to get question</param>
        /// <returns>
        /// String with question from server
        /// </returns>

        public static string GetQuestion(int numberOfQuestion)
        {
            string Question = "";
            using (WebClient wc = new WebClient())
            {
                string QuestionJSON = wc.DownloadString("https://swiktor.rzeszow.pl/WSIiZ/DogeQuiz/PHPs/GetQuestion.php?question=" + numberOfQuestion);
                var obj = new JavaScriptSerializer().Deserialize<dynamic>(QuestionJSON);
                if (obj != null)
                    Question = obj["question"];
            }
            return Question;
        }

        /// <summary>
        /// Method to get JSON data from server about correct answer base on question ID
        /// </summary>
        /// <param name="numberOfQuestion">Number of question to get correct answer</param>
        /// <returns>
        /// String with correct answer from server
        /// </returns>

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

        /// <summary>
        /// Method to get JSON data from server about answers base on question ID
        /// </summary>
        /// <param name="numberOfQuestion">Number of question to get answers</param>
        /// <returns>
        /// List of string with answers from server
        /// </returns>

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

