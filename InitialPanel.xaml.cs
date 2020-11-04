using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace FirstFantasy_FinalExam
{
    /// <summary>
    /// Lógica de interacción para InitialPanel.xaml
    /// </summary>
    public partial class InitialPanel : Page
    {
        public InitialPanel()
        {
            InitializeComponent();
        }
        string path = @"C:\Users\Cristian\source\Repos\FistFantasy_FinalExam\Extra\UsersAndPasswords.txt";
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            bool correctInformation = false;
            string s = "|";
            char c = Convert.ToChar(s);
            string[] content = File.ReadAllLines(path);
            for (int i = 0; i < content.Length; i++)
            {
                string user = "";
                string password = "";
                int count = 0;
                foreach (char j in content[i])
                {
                    if (j != c)
                    {
                        if (count == 0)
                        {
                            user += j;
                        }
                        else
                        {
                            password += j;
                        }
                    }
                    else
                    {
                        count = 1;
                    }
                }
                if (txtUser.Text == user && txtPassword.Password == password)
                {
                    correctInformation = true;
                    MessageBox.Show("Your login was successful", "¡Welcome!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    MainWindow w = (MainWindow)Window.GetWindow(this);
                    w.mainFrame.NavigationService.Navigate(new MyCharacters());
                    break;
                }
            }
            if (correctInformation == false)
            {
                MessageBox.Show("Wrong username and/or password", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            string textToAppend = "\n" + txtUser.Text + "|" + txtPassword.Password;
            File.AppendAllText(path, textToAppend);
            MessageBox.Show("Your registration was successful, go and check it out yourself by logging in", "¡Congratulations!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            txtUser.Text = "";
            txtPassword.Password = "";
        }
    }
}
