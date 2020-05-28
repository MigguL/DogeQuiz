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
        readonly Description descr = new Description();

        //Initialize all window functionalities
        public Form3()
        {
            InitializeComponent();
            ShowDog(numDog);
        }

        //Escape click button, after clicking move user to the main menu
        private void ESCButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow Menu = new MainWindow();
            Menu.Show();
            Close();
        }

        //After clicking button, move to the previous dog description 
        private void PreviousDogDescr_Click(object sender, RoutedEventArgs e)
        {
            if (numDog > 1)
            {
                numDog--;
                ShowDog(numDog);
            }
        }

        //After clicking button, move to the next dog description 
        private void NextDogDescr_Click(object sender, RoutedEventArgs e)
        {
            if (numDog < 5)
            {
                numDog++;
                ShowDog(numDog);
            }
        }

        //Displaying all races one by one with the option of scrolling photos
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
                case 3:
                    {
                        dPath = @"Resources\Form3\dog03\descr03.txt";
                        descr.ReadFile(dPath);
                        DogDescr.Text = descr.FileText;

                        img01.Source = new BitmapImage(new Uri(@"Resources\Form3\dog03\img01.jpg", UriKind.Relative));
                        img02.Source = new BitmapImage(new Uri(@"Resources\Form3\dog03\img02.jpg", UriKind.Relative));
                        img03.Source = new BitmapImage(new Uri(@"Resources\Form3\dog03\img03.jpg", UriKind.Relative));
                        img04.Source = new BitmapImage(new Uri(@"Resources\Form3\dog03\img04.jpg", UriKind.Relative));
                        break;
                    }
                case 4:
                    {
                        dPath = @"Resources\Form3\dog04\descr04.txt";
                        descr.ReadFile(dPath);
                        DogDescr.Text = descr.FileText;

                        img01.Source = new BitmapImage(new Uri(@"Resources\Form3\dog04\img01.jpg", UriKind.Relative));
                        img02.Source = new BitmapImage(new Uri(@"Resources\Form3\dog04\img02.jpg", UriKind.Relative));
                        img03.Source = new BitmapImage(new Uri(@"Resources\Form3\dog04\img03.jpg", UriKind.Relative));
                        img04.Source = new BitmapImage(new Uri(@"Resources\Form3\dog04\img04.jpg", UriKind.Relative));
                        break;
                    }
                case 5:
                    {
                        dPath = @"Resources\Form3\dog05\descr05.txt";
                        descr.ReadFile(dPath);
                        DogDescr.Text = descr.FileText;

                        img01.Source = new BitmapImage(new Uri(@"Resources\Form3\dog05\img01.jpg", UriKind.Relative));
                        img02.Source = new BitmapImage(new Uri(@"Resources\Form3\dog05\img02.jpg", UriKind.Relative));
                        img03.Source = new BitmapImage(new Uri(@"Resources\Form3\dog05\img03.jpg", UriKind.Relative));
                        img04.Source = new BitmapImage(new Uri(@"Resources\Form3\dog05\img04.jpg", UriKind.Relative));
                        break;
                    }
            }
        }
    }
}
