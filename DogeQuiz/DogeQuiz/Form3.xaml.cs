using System;
using System.Windows;
using System.Windows.Media.Imaging;


namespace DogeQuiz
{
    /// <summary>
    /// Interaction logic for Form3.xaml
    /// </summary>
    public partial class Form3 : Window
    {
        public int numDog = 1;
        public string dPath;
        Description descr = new Description();

        public Form3()
        {
            InitializeComponent();
            ShowDog(numDog);
        }

        private void ESCButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow Menu = new MainWindow();
            Menu.Show();
            Close();
        }

        private void PreviousDogDescr_Click(object sender, RoutedEventArgs e)
        {
            if (numDog > 1)
            {
                numDog--;
                ShowDog(numDog);
            }
        }

        private void NextDogDescr_Click(object sender, RoutedEventArgs e)
        {
            if (numDog < 2)
            {
                numDog++;
                ShowDog(numDog);
            }
        }

        public void ShowDog(int numDog)
        {
            switch (numDog)
            {
                case 1:
                    {
                        dPath = @"Resources\Form3\dog01\descr01.txt";
                        descr.ReadFile(dPath);
                        DogDescr.Text = descr.FileText;

                        img01.Source = new BitmapImage(new Uri(@"Resources\Form3\dog01\img01.jpg", UriKind.Relative));
                        img02.Source = new BitmapImage(new Uri(@"Resources\Form3\dog01\img02.jpg", UriKind.Relative));
                        img03.Source = new BitmapImage(new Uri(@"Resources\Form3\dog01\img03.jpg", UriKind.Relative));
                        img04.Source = new BitmapImage(new Uri(@"Resources\Form3\dog01\img04.jpg", UriKind.Relative));
                        break;
                    }
                case 2:
                    {
                        dPath = @"Resources\Form3\dog02\descr02.txt";
                        descr.ReadFile(dPath);
                        DogDescr.Text = descr.FileText;

                        img01.Source = new BitmapImage(new Uri(@"Resources\Form3\dog02\img01.jpg", UriKind.Relative));
                        img02.Source = new BitmapImage(new Uri(@"Resources\Form3\dog02\img02.jpg", UriKind.Relative));
                        img03.Source = new BitmapImage(new Uri(@"Resources\Form3\dog02\img03.jpg", UriKind.Relative));
                        img04.Source = new BitmapImage(new Uri(@"Resources\Form3\dog02\img04.jpg", UriKind.Relative));
                        break;
                    }
            }
        }
    }
}
