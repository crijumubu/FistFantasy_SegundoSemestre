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
        List<Character> createdCharacters = new List<Character>();
        List<Weapon> createdWeapons = new List<Weapon>();
        IDescribable describable; //Se usa en especial para objetos como pociones, armadura, etc.

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
                        createdCharacters.Add(new Cleric());
                        break;
                    case "Fighter":
                        createdCharacters.Add(new Fighter());
                        break;
                    case "Rogue":
                        createdCharacters.Add(new Rogue());
                        break;
                    case "Wizard":
                        createdCharacters.Add(new Wizard());
                        break;
                }
                createdCharacters[count].ID = count.ToString();
                createdCharacters[count].Name = name;
                createdCharacters[count].Type = selectCharacter;

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
                createdCharacters[count].CurrentWeapon = createdWeapons[count];

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
                createdCharacters[count].AddToInventory(describable);

                datOutPut.Items.Add(createdCharacters[count]);

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
            createdCharacters[actualColum].Name = txtName.Text;
            datOutPut.Items.Clear();
            foreach (Character c in createdCharacters)
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
                createdCharacters.Clear();
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
    }
}