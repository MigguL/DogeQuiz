﻿using System;
using System.Reflection;
using System.Resources;
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

        /// <summary>
        /// Initialize all window functionalities
        /// </summary>
        public Form3()
        {
            InitializeComponent();
            ShowDog(numDog);
        }

        /// <summary>
        /// Interaction for escape button, after clicking move user to the main menu
        /// </summary>
        private void ESCButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow Menu = new MainWindow();
            Menu.Show();
            Close();
        }

        /// <summary>
        /// After clicking button, move to the previous dog description 
        /// </summary>
        private void PreviousDogDescr_Click(object sender, RoutedEventArgs e)
        {
            if (numDog > 1)
            {
                numDog--;
                ShowDog(numDog);
            }
        }

        /// <summary>
        /// After clicking button, move to the next dog description 
        /// </summary>
        private void NextDogDescr_Click(object sender, RoutedEventArgs e)
        {
            if (numDog < 5)
            {
                numDog++;
                ShowDog(numDog);
            }
        }

        ///<summary>
        /// Displaying all races one by one with the option of scrolling photos
        ///</summary>
        public void ShowDog(int numDog)
        {
            switch (numDog)
            {
                case 1:
                    {
                        DogDescr.Text = Properties.Resources.ResourceManager.GetString("Form3_dog01_descr01");
                    
                        img01.Source = new BitmapImage(new Uri(@"Resources\Form3\dog01\img01.jpg", UriKind.Relative));
                        img02.Source = new BitmapImage(new Uri(@"Resources\Form3\dog01\img02.jpg", UriKind.Relative));
                        img03.Source = new BitmapImage(new Uri(@"Resources\Form3\dog01\img03.jpg", UriKind.Relative));
                        img04.Source = new BitmapImage(new Uri(@"Resources\Form3\dog01\img04.jpg", UriKind.Relative));
                        break;
                    }
                case 2:
                    {
                        DogDescr.Text = Properties.Resources.ResourceManager.GetString("Form3_dog02_descr02");

                        img01.Source = new BitmapImage(new Uri(@"Resources\Form3\dog02\img01.jpg", UriKind.Relative));
                        img02.Source = new BitmapImage(new Uri(@"Resources\Form3\dog02\img02.jpg", UriKind.Relative));
                        img03.Source = new BitmapImage(new Uri(@"Resources\Form3\dog02\img03.jpg", UriKind.Relative));
                        img04.Source = new BitmapImage(new Uri(@"Resources\Form3\dog02\img04.jpg", UriKind.Relative));
                        break;
                    }
                case 3:
                    {
                        DogDescr.Text = Properties.Resources.ResourceManager.GetString("Form3_dog03_descr03");

                        img01.Source = new BitmapImage(new Uri(@"Resources\Form3\dog03\img01.jpg", UriKind.Relative));
                        img02.Source = new BitmapImage(new Uri(@"Resources\Form3\dog03\img02.jpg", UriKind.Relative));
                        img03.Source = new BitmapImage(new Uri(@"Resources\Form3\dog03\img03.jpg", UriKind.Relative));
                        img04.Source = new BitmapImage(new Uri(@"Resources\Form3\dog03\img04.jpg", UriKind.Relative));
                        break;
                    }
                case 4:
                    {
                        DogDescr.Text = Properties.Resources.ResourceManager.GetString("Form3_dog04_descr04");

                        img01.Source = new BitmapImage(new Uri(@"Resources\Form3\dog04\img01.jpg", UriKind.Relative));
                        img02.Source = new BitmapImage(new Uri(@"Resources\Form3\dog04\img02.jpg", UriKind.Relative));
                        img03.Source = new BitmapImage(new Uri(@"Resources\Form3\dog04\img03.jpg", UriKind.Relative));
                        img04.Source = new BitmapImage(new Uri(@"Resources\Form3\dog04\img04.jpg", UriKind.Relative));
                        break;
                    }
                case 5:
                    {
                        DogDescr.Text = Properties.Resources.ResourceManager.GetString("Form3_dog05_descr05");

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
