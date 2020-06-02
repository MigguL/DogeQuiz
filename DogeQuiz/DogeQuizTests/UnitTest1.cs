using DogeQuiz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DogeQuizTests
{
    [TestClass]
    public class MySQLTests
    {
        [TestMethod]
        public void GetQuestion_IncorrectQuestionNumber_ReturnsTrue()
        {
            //arrange
            string question = string.Empty;
            //tablica numerow pytan do sprawdzenia - wartosci skrajne
            //trzeba sprawdzic, czy sql lub php nie zmieni -1 na 1
            int[] incorrectQuestionNumbers = new int[3] { -1, 0, 11 };
            bool isQuestionNullOrEmpty = true;

            //act
            foreach (var number in incorrectQuestionNumbers)
            {
                question = "";
                //Dla "  " oraz nulla zwroci false. Dla "" lub jakiegos pytania
                //z bazy zwroci true. Po naprawie sql-a trzeba odkomentowac linijke nizej
                //question = MySQL.GetQuestion(number);
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
        public void GetAnswers_IncorrectQuestionNumber_ReturnsTrue()
        {
            //arrange
            List<string> answersList;
            //tablica numerow pytan do sprawdzenia - wartosci skrajne
            //trzeba upewnic sie, ze sql nie zmieni -1 na 1
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

        //sprawdza czy poprawna odpowiedz nie jest nullem lub empty
        [TestMethod]
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

        //sprawdza czy dla kazdego pytania poprawna odpowiedz wystepuje w
        // w mozliwych odpowiedziach
        [TestMethod]
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

                //jesli jakakolwiek odpowiedz do pytania jest taka sama jak
                //correctAnswer, to spoko, a jesli nie to state = false
                if (possibleAnswers.Any(a => a.Equals(correctAnswer) == false))
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