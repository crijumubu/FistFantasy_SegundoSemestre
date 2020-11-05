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
        string name = "";
        string selectCharacter = "";
        string selectWeapon = "";
        string selectEquipment = "";
        int count = 0;
        bool correctData = false;
        bool modify = false;
        //static List <Character> createdCharacters = new List<Character>();
        List<Weapon> createdWeapons = new List<Weapon>();
        IDescribable describable; //Se usa en especial para objetos como pociones, armadura, etc.

        //public static List<Character> CreatedCharacters { get => createdCharacters; set => createdCharacters = value; }

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
                Character.CreatedCharacters[count].ID = count.ToString();
                Character.CreatedCharacters[count].Name = name;
                Character.CreatedCharacters[count].Type = selectCharacter;

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
                Character.CreatedCharacters[count].CurrentWeapon = createdWeapons[count];

                switch (selectEquipment)
                {
                    case "Armor":
                        describable = new Armor();
                        break;
                    case "Boot":
                        describable = new Boot();
                        break;
                    case "Parachute":
                        describable = new Parachute();
                        break;
                    case "Potion":
                        describable = new Potion();
                        break;
                }
                Character.CreatedCharacters[count].AddToInventory(describable);

                datOutPut.Items.Add(Character.CreatedCharacters[count]);

                MessageBox.Show("The character has been created correctly", "¡Successful application!");
                txtName.Text = "";
                cmbCharacter.Text = "";
                cmbWeapon.Text = "";
                cmbEqipment.Text = "";
                count++;
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
                count = 0;
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
    }
}