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
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to PERMANENTLY remove all your characters?", "Remove", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                createdCharacters.Clear();
                datOutPut.Items.Clear();
                count = 0;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            /*string[] data = new string[5];
            datOutPut.Items.CopyTo(data, 0);
            txtName.Text = data[1];
            cmbCharacter.SelectedItem = data[2];
            cmbWeapon.SelectedItem = data[3];
            cmbEqipment.SelectedItem = data[4];*/
            MessageBox.Show("We're working on this functionality. We regret the inconvenience caused", "¡Error!",MessageBoxButton.OK,MessageBoxImage.Error);
        }
    }
}
