using FirstFantasy_FinalExam.Classes.Player;
using FirstFantasy_FinalExam.Classes.Equipment;
using FirstFantasy_FinalExam.Interfaces;
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
    /// Lógica de interacción para Inventory.xaml
    /// </summary>
    public partial class Inventory : Page
    {
        public Inventory()
        {
            InitializeComponent();
        }
        List<IDescribable> inventory = new List<IDescribable>();
        List<string> charactersName = new List<string>();
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (Character.CreatedCharacters.Count != 0)
            {
                foreach (Character c in Character.CreatedCharacters)
                {
                    charactersName.Add(c.Name);
                }
                cmbMyCharacters.ItemsSource = charactersName;
                MessageBox.Show("All your characters have been loaded. Check it out by yourself", "Successful application", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Sorry, you haven't created any characters. Go and create one to view its equipment", "!Invalid application¡", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            List<string> equipmentsName = new List<string>() { "Armor", "Ax", "Boomerang", "Boot", "Bow", "Parachute", "Potion", "Sword" };
            List<int> equipmentValue = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 };
            int index = cmbMyCharacters.SelectedIndex;
            if (index != -1)
            {
                inventory = Character.CreatedCharacters[index].Inventory;
                foreach (IEquipment i in inventory)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (i.Type() == equipmentsName[j])
                        {
                            equipmentValue[j] += 1;
                        }
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    if (equipmentValue[i] != 0)
                    {
                        txtOutputInventory.Text += "Item: " + equipmentsName[i] + "\n" + "Number: " + equipmentValue[i] + "\n";
                    }
                }
            }
            else
            {
                MessageBox.Show("Please pick one of your characters to view its equipment", "!Error¡", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.mainFrame.NavigationService.Navigate(new MyCharacters());
        }
    }
}
