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

        /// <summary>
        /// Interaction for quiz button
        /// </summary>

        private void quizButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Form2 Game = new Form2();
            Game.ShowDialog();
            Close();
        }

        /// <summary>
        /// Interaction for informations about dogs button
        /// </summary>

        private void DogsButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Form3 Dogs = new Form3();
            Dogs.ShowDialog();
            Close();
        }
    }
}

