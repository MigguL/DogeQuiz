using DogeQuiz;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DogeQuizTests
{
    [TestClass]
    public class MySQLTests
    {
        private const int ExpectedQuestionsCount = 10;
        private const int ExpectedGetAnswersCount = 3;

        [TestMethod]
        public void QuestionsCountTestMethod()
        {
            int QuestionsCountMySQL = MySQL.GetQuestionsCount();
            Assert.AreEqual(ExpectedQuestionsCount, QuestionsCountMySQL);
        }

        [TestMethod]
        public void GetAnswersTest()
        {
            bool state = false;

            for (int i = 0; i <= ExpectedQuestionsCount; i++)
            {
                var answersList = MySQL.GetAnswers(i);

                if (answersList.Count == ExpectedGetAnswersCount)
                {
                    state = true;
                }
                else
                {
                    state = false;
                }
            }
            Assert.AreEqual(true, state);
        }
    }
}
