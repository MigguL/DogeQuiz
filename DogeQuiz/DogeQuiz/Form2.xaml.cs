using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using static DogeQuiz.MySQL;

namespace DogeQuiz
{

    /// <summary>
    /// Interaction logic for Form2.xaml
    /// </summary>
    /// 
    public partial class Form2 : Window
    {
        public List<Answers> listOfAnswers = new List<Answers>();

        public int numberOfQuestion = 1,
                   numberOfCorrectAnswer = 0,
                   points = 0,
                   imageIterator = 2;
        public string guess;
        public string question;
        public string correctAnswer;
        public int QuestionsCount = GetQuestionsCount();

        //Initialize field with checkbox A
        private void CheckBoxA_Checked(object sender, RoutedEventArgs e)
        {
            guess = listOfAnswers[0].AnswerA;
            CheckBoxB.IsChecked = false;
            CheckBoxC.IsChecked = false;
        }

        //Initialize field with checkbox B
        private void CheckBoxB_Checked(object sender, RoutedEventArgs e)
        {
            guess = listOfAnswers[0].AnswerB;
            CheckBoxA.IsChecked = false;
            CheckBoxC.IsChecked = false;
        }

        //Initialize field with checkbox C
        private void CheckBoxC_Checked(object sender, RoutedEventArgs e)
        {
            guess = listOfAnswers[0].AnswerC;
            CheckBoxA.IsChecked = false;
            CheckBoxB.IsChecked = false;
        }

        //Initialize all window functionalities
        public Form2()
        {
            InitializeComponent();
            LoadQuestionsAndAnswers();
        }

        //Initialize all necessary functionalities for button
        private void NextQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            CheckTheAnswer();
            DisplayNextQuestion();
        }

        //Display first question 
        public void LoadQuestionsAndAnswers()
        {
            GetQandA();
            questionBoxText.Text = question;
            answerAText.Text = $" A. {listOfAnswers[0].AnswerA}";
            answerBText.Text = $" B. {listOfAnswers[0].AnswerB}";
            answerCText.Text = $" C. {listOfAnswers[0].AnswerC}";
            dogsQuizImg.Source = new BitmapImage(new Uri(@"Resources\Form2\image01.jpg", UriKind.Relative));
        }

        //Check answer if it is correct play sound, after check reset all checkboxes fields and passed answer
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

        //Displaying next question by checking number of it and switching between all 10 questions nextly and at the end there is displayed user interaction showing score and playing some sound
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

        //After clicking score window move the user to the start menu
        public void EndOfQuiz()
        {
            Hide();
            MainWindow menu = new MainWindow();
            menu.Show();
            Close();
        }


        public void GetQandA()
        {
            question = GetQuestion(numberOfQuestion);

            List<string> answers = GetAnswers(numberOfQuestion);

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
