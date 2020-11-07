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
using System.Reflection;
using System.Linq;

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
            if (Character.Change != 0)
            {
                btnUpdateTable.Visibility = Visibility.Visible;
            }
        }
        string name = "";
        string selectCharacter = "";
        string selectWeapon = "";
        string selectEquipment = "";
        static int countCharacters = 0;
        int countWeapons = 0;
        bool correctData = false;
        bool modify = false;
        List<Weapon> createdWeapons = new List<Weapon>();
        IEquipment equipment; //Se usa en especial para objetos como pociones, armadura, etc.

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            name = txtName.Text;
            selectCharacter = cmbCharacter.Text;
            selectWeapon = cmbWeapon.Text;
            selectEquipment = cmbEqipment.Text;
            if (name != "" && selectCharacter != "" && selectWeapon != "" && selectEquipment != "")
            {
                correctData = true;
            }
            else
            {
                correctData = false;
                MessageBox.Show("You've forgotten to fill in or select one of the fields. We can't go on without these, please complete them", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (correctData == true)
            {
                switch (cmbCharacter.Text)
                {
                    case "Cleric":
                        Character.CreatedCharacters.Add(new Cleric());
                        break;
                    case "Fighter":
                        Character.CreatedCharacters.Add(new Fighter());
                        break;
                    case "Rogue":
                        Character.CreatedCharacters.Add(new Rogue());
                        break;
                    case "Wizard":
                        Character.CreatedCharacters.Add(new Wizard());
                        break;
                }
                Character.CreatedCharacters[countCharacters].ID = countCharacters.ToString();
                Character.CreatedCharacters[countCharacters].Name = name;
                Character.CreatedCharacters[countCharacters].Type = selectCharacter;

                switch (selectWeapon)
                {
                    case "Ax":
                        createdWeapons.Add(new Ax());
                        break;
                    case "Boomerang":
                        createdWeapons.Add(new Boomerang());
                        break;
                    case "Bow":
                        createdWeapons.Add(new Bow());
                        break;
                    case "Sword":
                        createdWeapons.Add(new Sword());
                        break;
                }
                Character.CreatedCharacters[countCharacters].CurrentWeapon = createdWeapons[countWeapons];
                Character.CreatedCharacters[countCharacters].Inventory.Add(createdWeapons[countWeapons]);

                switch (selectEquipment)
                {
                    case "Armor":
                        equipment = new Armor();
                        break;
                    case "Boot":
                        equipment = new Boot();
                        break;
                    case "Parachute":
                        equipment = new Parachute();
                        break;
                    case "Potion":
                        equipment = new Potion();
                        break;
                }
                Character.CreatedCharacters[countCharacters].Inventory.Add(equipment);

                datOutPut.Items.Clear();
                foreach (Character c in Character.CreatedCharacters)
                {
                    datOutPut.Items.Add(c);
                }

                btnUpdateTable.Visibility = Visibility.Hidden;
                MessageBox.Show("The character has been created correctly", "¡Successful application!", MessageBoxButton.OK, MessageBoxImage.Information);
                txtName.Text = "";
                cmbCharacter.Text = "";
                cmbWeapon.Text = "";
                cmbEqipment.Text = "";
                countCharacters++;
                Character.Change = 0;
            }
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int actualColum = datOutPut.SelectedIndex;
            Character.CreatedCharacters[actualColum].Name = txtName.Text;
            datOutPut.Items.Clear();
            foreach (Character c in Character.CreatedCharacters)
            {
                datOutPut.Items.Add(c);
            }
            lblHolder.Content = "Create a new character";
            btnModify.Content = "Modify";
            btnUpdate.Visibility = Visibility.Hidden;
            btnCreate.Visibility = Visibility.Visible;
            txtName.Text = "";
            modify = false;
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to PERMANENTLY remove all your characters?", "Remove", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Character.CreatedCharacters.Clear();
                datOutPut.Items.Clear();
                txtName.Text = "";
                cmbCharacter.Text = "";
                cmbWeapon.Text = "";
                cmbEqipment.Text = "";
                countCharacters = 0;
                countWeapons = 0;
            }
        }
        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {
            if (modify == true)
            {
                lblHolder.Content = "Create a new character";
                btnModify.Content = "Modify";
                btnUpdate.Visibility = Visibility.Hidden;
                btnCreate.Visibility = Visibility.Visible;
                modify = false;
            }
            else
            {
                MessageBox.Show("If you want to modify your character you must select it in the table. Remember that you only can change your character's name", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DatOutPut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datOutPut.SelectedIndex != -1)
            {
                modify = true;
                lblHolder.Content = "Modify your character";
                btnModify.Content = "Stop modifying";
                btnUpdate.Visibility = Visibility.Visible;
                btnCreate.Visibility = Visibility.Hidden;
                Character characterSelected = datOutPut.SelectedItem as Character;
                txtName.Text = characterSelected.Name;
            }
            else
            {

                modify = false;
            }
        }

        private void BtnInventory_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.mainFrame.NavigationService.Navigate(new Inventory());
        }

        private void BtnUpdateTable_Click(object sender, RoutedEventArgs e)
        {
            foreach (Character c in Character.CreatedCharacters)
            {
                datOutPut.Items.Add(c);
            }
            btnUpdateTable.Visibility = Visibility.Hidden;
            MessageBox.Show("All your characters have been loaded. Check it out by yourself", "Successful application", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.mainFrame.NavigationService.Navigate(new InitialPanel());
        }
    }
}