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
using System.Diagnostics;
using System.Windows.Navigation;
using System.Net;

namespace FirstFantasy_FinalExam
{
    /// <summary>
    /// Lógica de interacción para InitialPanel.xaml
    /// </summary>
    public partial class InitialPanel : Page
    {
        string pathFolder = @"C: \Users\Administrador\source\Repos\FistFantasy_FinalExam\Extra";
        string pathTxT = @"C:\Users\Administrador\source\Repos\FistFantasy_FinalExam\Extra\UsersAndPasswords.txt";
        public InitialPanel()
        {
            InitializeComponent();
            webOutPut.Visibility = Visibility.Hidden;
            if (Directory.Exists(pathFolder) == false)
            {
                Directory.CreateDirectory(pathFolder);
            }
            EmptyFolder(new DirectoryInfo(pathFolder));
            if (File.Exists(pathTxT) == false)
            {
                StreamWriter stream = new StreamWriter(pathTxT);
            }
        }
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            bool correctInformation = false;
            string s = "|";
            char c = Convert.ToChar(s);
            string[] content = File.ReadAllLines(pathTxT);
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
                    MessageBox.Show("Your login was successful", "¡Welcome!", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow w = (MainWindow)Window.GetWindow(this);
                    w.mainFrame.NavigationService.Navigate(new MyCharacters());
                    break;
                }
            }
            if (correctInformation == false)
            {
                MessageBox.Show("Wrong username and/or password", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUser.Text = "";
                txtPassword.Password = "";
            }
        }
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text != "" && txtPassword.Password != "")
            {
                string textToAppend = txtUser.Text + "|" + txtPassword.Password + "\n";
                File.AppendAllText(pathTxT, textToAppend);
                MessageBox.Show("Your registration was successful, go and check it out yourself by logging in", "¡Congratulations!", MessageBoxButton.OK, MessageBoxImage.Information);
                txtUser.Text = "";
                txtPassword.Password = "";
            }
            else
            {
                MessageBox.Show("Please type a valid username and/or password", "!Error¡", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnManage_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("You've accessed to the administrator roles. As an administrator, you have the option to delete user records and passwords Are you sure you want to permanently delete the records?", "Administrador", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                File.WriteAllText(pathTxT, "");
                MessageBox.Show("The records were deleted successfully", "¡Successful application!");
                txtUser.Text = "";
                txtPassword.Password = "";
            }
        }
        private void EmptyFolder(DirectoryInfo directoryInfo)
        {
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
            {
                EmptyFolder(subfolder);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (webOutPut.Visibility == Visibility.Hidden)
            {
                webOutPut.Visibility = Visibility.Visible;
                btnWeb.Content = "Exit the album";
                btnWeb.Width = 97;
            }
            else
            {
                webOutPut.Visibility = Visibility.Hidden;
                btnWeb.Content = "Take a look to our characters and map";
                btnWeb.Width = 228;
            }
            
        }
    }
}
