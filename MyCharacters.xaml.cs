using FirstFantasy_FinalExam.Classes.Player;
using FirstFantasy_FinalExam.Classes.Equipment;
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

namespace FirstFantasy_FinalExam
{
    /// <summary>
    /// Lógica de interacción para MyCharacters.xaml
    /// </summary>
    public partial class MyCharacters : Page
    {
        public MyCharacters()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Character c in Character.Createdcharacters)
            {
                datOutPut.Items.Add(c);
            }
        }
    }
}
