using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Media.Imaging;
using static DogeQuiz.SQLite;
using static DogeQuiz.MySQL;

namespace DogeQuiz
{

    /// <summary>
    /// Interaction logic for Form2.xaml
    /// </summary>
    /// 
    public partial class Form2 : Window
    {
        public string qPath = @"Resources\questions.txt";
        public string aPath = @"Resources\answers.txt";
        public List<Questions> listOfQuestions = new List<Questions>();
        public List<Answers> listOfAnswers = new List<Answers>();

        public int numberOfQuestion = 1,
                   numberOfCorrectAnswer = 0,
                   points = 0,
                   imageIterator = 2;
        public string guess;
        public string question;
        public string correctAnswer;
        public int QuestionsCount = GetQuestionsCount();

        private void CheckBoxA_Checked(object sender, RoutedEventArgs e)
        {
            guess = listOfAnswers[0].AnswerA;
            CheckBoxB.IsChecked = false;
            CheckBoxC.IsChecked = false;
        }

        private void CheckBoxB_Checked(object sender, RoutedEventArgs e)
        {
            guess = listOfAnswers[0].AnswerB;
            CheckBoxA.IsChecked = false;
            CheckBoxC.IsChecked = false;
        }

        private void CheckBoxC_Checked(object sender, RoutedEventArgs e)
        {
            guess = listOfAnswers[0].AnswerC;
            CheckBoxA.IsChecked = false;
            CheckBoxB.IsChecked = false;
        }
        public Form2()
        {
            InitializeComponent();
            LoadQuestionsAndAnswers();
        }

        private void NextQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            CheckTheAnswer();
            DisplayNextQuestion();
        }

        public void LoadQuestionsAndAnswers()
        {
            List<string> lines = File.ReadAllLines(qPath).ToList();
            // reading questions from the text file
            foreach (var line in lines)
            {
                listOfQuestions.Add(new Questions { Question = line });
            }


            //List<string> answers = File.ReadAllLines(aPath).ToList();
            // reading answers from the text file


            GetQandA();

            //displaying the first question
            questionBoxText.Text = question;
            answerAText.Text = $" A. {listOfAnswers[0].AnswerA}";
            answerBText.Text = $" B. {listOfAnswers[0].AnswerB}";
            answerCText.Text = $" C. {listOfAnswers[0].AnswerC}";
            dogsQuizImg.Source = new BitmapImage(new Uri(@"Resources\Form2\image01.jpg", UriKind.Relative));
        }

        public void CheckTheAnswer()
        {
            if (guess == correctAnswer)
            {
                if (numberOfQuestion < QuestionsCount)
                {
                    SoundPlayer splayer = new SoundPlayer(@"Resources\Sound\correctAnswer.wav");
                    splayer.Play();
                }
                points++;
            }

            CheckBoxA.IsChecked = false;
            CheckBoxB.IsChecked = false;
            CheckBoxC.IsChecked = false;
            guess = "";
        }

        public void DisplayNextQuestion()
        {
            if (numberOfQuestion < QuestionsCount)
            {
                numberOfQuestion++;
                GetQandA();
                questionBoxText.Text = question;
                answerAText.Text = $" A. {listOfAnswers[0].AnswerA}";
                answerBText.Text = $" B. {listOfAnswers[0].AnswerB}";
                answerCText.Text = $" C. {listOfAnswers[0].AnswerC}";

                switch (imageIterator)
                {
                    case 1:
                        { dogsQuizImg.Source = new BitmapImage(new Uri(@"Resources\Form2\image01.jpg", UriKind.Relative)); break; }
                    case 2:
                        { dogsQuizImg.Source = new BitmapImage(new Uri(@"Resources\Form2\image02.jpg", UriKind.Relative)); break; }
                    case 3:
                        { dogsQuizImg.Source = new BitmapImage(new Uri(@"Resources\Form2\image03.jpg", UriKind.Relative)); break; }
                    case 4:
                        { dogsQuizImg.Source = new BitmapImage(new Uri(@"Resources\Form2\image04.jpg", UriKind.Relative)); break; }
                    case 5:
                        { dogsQuizImg.Source = new BitmapImage(new Uri(@"Resources\Form2\image05.jpg", UriKind.Relative)); break; }
                    case 6:
                        { dogsQuizImg.Source = new BitmapImage(new Uri(@"Resources\Form2\image06.jpg", UriKind.Relative)); break; }
                    case 7:
                        { dogsQuizImg.Source = new BitmapImage(new Uri(@"Resources\Form2\image07.jpg", UriKind.Relative)); break; }
                    case 8:
                        { dogsQuizImg.Source = new BitmapImage(new Uri(@"Resources\Form2\image08.jpg", UriKind.Relative)); break; }
                    case 9:
                        { dogsQuizImg.Source = new BitmapImage(new Uri(@"Resources\Form2\image09.jpg", UriKind.Relative)); break; }
                    case 10:
                        { dogsQuizImg.Source = new BitmapImage(new Uri(@"Resources\Form2\image10.jpg", UriKind.Relative)); break; }
                }
                imageIterator++;
            }
            else if ((numberOfQuestion >= QuestionsCount) && (points >= 6))
            {
                SoundPlayer splayer = new SoundPlayer(@"Resources\Sound\morethan6.wav");
                splayer.Play();
                MessageBox.Show($"{points}/{QuestionsCount} punktów. Jesteś ekspertem!");
                EndOfQuiz();
            }
            else if ((numberOfQuestion >= QuestionsCount) && (points <= 5))
            {
                SoundPlayer splayer = new SoundPlayer(@"Resources\Sound\lessthan5.wav");
                splayer.Play();
                MessageBox.Show($"{points}/{QuestionsCount} punktów. Spróbuj ponownie");
                EndOfQuiz();
            }
        }

        public void EndOfQuiz()
        {
            this.Hide();
            MainWindow menu = new MainWindow();
            menu.Show();
            this.Close();
        }


        public void GetQandA()
        {
            SqliteConnection sqlite_conn;
            sqlite_conn = CreateConnection();

            if (tableExists("questions", sqlite_conn) == false)
            {
                CreateTable(sqlite_conn);
                InsertData(sqlite_conn);
            }

            question = GetQuestion(numberOfQuestion);


            SqliteDataReader answers_sdr = ReadAnswers(sqlite_conn, numberOfQuestion);

            List<string> answers = GetAnswers(numberOfQuestion);

            //while (answers_sdr.Read())
            //{
            //    answers.Add(answers_sdr.GetString(0));
            //    answers.Add(answers_sdr.GetString(1));
            //}

            listOfAnswers = new List<Answers>();

            listOfAnswers.Add(new Answers
            {
                AnswerA = answers[0],
                AnswerB = answers[1],
                AnswerC = answers[2],
            });


            correctAnswer = GetCorrectAnswer(numberOfQuestion);
            GetAnswers(numberOfQuestion);
        }

    }
}
