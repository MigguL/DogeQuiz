using System.Windows;

namespace DogeQuiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void quizButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Form2 Game = new Form2();
            Game.ShowDialog();
            Close();
        }

        private void DogsButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Form3 Dogs = new Form3();
            Dogs.ShowDialog();
            Close();
        }
    }
}

