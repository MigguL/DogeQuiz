using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DogeQuiz.UnitTests
{
    [TestClass]
    public class MySQLTests
    {

        [TestMethod]

        ///<summary>
        ///Test that checks quantity of questions
        ///</summary>
        public void QuestionsCount_CheckNumberOfQuestions_ReturnsTen()
        {
            //arrange
            int expectedQuestionsCount = 10;
            //act
            int questionsCountMySQL = MySQL.GetQuestionsCount();
            //assert
            Assert.AreEqual(expectedQuestionsCount, questionsCountMySQL);
        }

        [TestMethod]

        ///<summary>
        ///Test assures that given question index which is out of collection bounds returns empty string (content)
        ///</summary>
        public void GetQuestion_IncorrectQuestionNumber_ReturnsTrue()
        {
            //arrange
            string question = string.Empty;
            int[] incorrectQuestionNumbers = new int[3] { -1, 0, 11 };
            bool isQuestionNullOrEmpty = true;

            //act
            foreach (var number in incorrectQuestionNumbers)
            {
                question = MySQL.GetQuestion(number);
                if (string.IsNullOrEmpty(question) == false)
                {
                    isQuestionNullOrEmpty = false;
                    break;
                }
            }

            //assert
            Assert.IsTrue(isQuestionNullOrEmpty);
        }

        [TestMethod]

        ///<summary>
        ///Test assures that given question index which is out of collection bounds returns 0 answers
        ///</summary>
        public void GetAnswers_IncorrectQuestionNumber_ReturnsTrue()
        {
            //arrange
            List<string> answersList;
            int[] incorrectQuestionNumbers = new int[3] { -1, 0, 11 };
            int expectedGetAnswersCount = 0;
            bool resultState = true;

            //act
            foreach (var number in incorrectQuestionNumbers)
            {
                answersList = MySQL.GetAnswers(number);
                if (answersList.Count != expectedGetAnswersCount)
                {
                    resultState = false;
                    break;
                }
            }

            //assert
            Assert.IsTrue(resultState);
        }

        [TestMethod]

        ///<summary>
        ///Test that checks quantity of answers for each question
        ///</summary>

        public void GetAnswers_CheckEveryQuestionNumberOfAnswers_ReturnsTrue()
        {
            //arrange
            List<string> answersList = new List<string>();
            int expectedQuestionsCount = 10;
            int expectedGetAnswersCount = 3;
            bool state = true;

            //act
            for (int i = 1; i <= expectedQuestionsCount; i++)
            {
                answersList = MySQL.GetAnswers(i);

                if (answersList.Count != expectedGetAnswersCount)
                {
                    state = false;
                    break;
                }
            }

            //assert
            Assert.IsTrue(state);
        }

        [TestMethod]

        /// <summary>
        /// The test checks if the correct answer is not null nor empty
        /// </summary>
        public void GetCorrectAnswer_CheckNotEmpty_ReturnsTrue()
        {
            //arrange
            int expectedQuestionsCount = 10;
            bool state = true;

            //act
            for (int i = 1; i <= expectedQuestionsCount; i++)
            {
                string correctAnswer = MySQL.GetCorrectAnswer(i);

                if (string.IsNullOrEmpty(correctAnswer) || correctAnswer.Length == 0)
                {
                    state = false;
                    break;
                }
            }

            //assert
            Assert.IsTrue(state);
        }

        
        [TestMethod]

        /// <summary>
        /// The test checks if for each question correct answer exists in collection of possible answers
        /// </summary>
        public void CorrectAnswerEquality_ReturnsTrue()
        {
            //arrange
            bool state = true;
            int expectedQuestionsCount = 10;

            //act
            for (int i = 1; i <= expectedQuestionsCount; i++)
            {

                string[] possibleAnswers = MySQL.GetAnswers(i).ToArray();
                string correctAnswer = MySQL.GetCorrectAnswer(i);

                if (possibleAnswers.All(a => a.Equals(correctAnswer) == false))
                {
                    state = false;
                    break;
                }
            }

            //assert
            Assert.IsTrue(state);
        }
    }
}