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
        List<IEquipment> inventory = new List<IEquipment>();
        List<string> charactersName = new List<string>();
        List<string> actualWeapons = new List<string>();
        List<string> equipmentsName = new List<string>() { "Armor", "Ax", "Boomerang", "Boot", "Bow", "Parachute", "Potion", "Sword" };

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (Character.CreatedCharacters.Count != 0 && cmbMyCharacters.Text != "")
            {
                int index = cmbMyCharacters.SelectedIndex;
                cmbCurrentWeapon.Items.Clear();
                foreach (IEquipment i in Character.CreatedCharacters[index].Inventory)
                {
                    foreach (string j in equipmentsName)
                    {
                        if (i.Type() == j && i.Type() != "Armor" && i.Type() != "Boot" && i.Type() != "Parachute" && i.Type() != "Potion")
                        {
                            actualWeapons.Add(j);
                            cmbCurrentWeapon.Items.Add(j);
                        }
                    }
                }
                MessageBox.Show("All your characters and their information have been loaded ", "¡Successful application!", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbAddWeapons.Text = "";
                cmbAddEquipment.Text = "";
                cmbCurrentWeapon.Text = "";
                lblCharacter.Content = "Character's name: "+cmbMyCharacters.Text;
                btnUpdate.Visibility = Visibility.Visible;
                btnChangeCharacter.Visibility = Visibility.Visible;
                btnSearch.Visibility = Visibility.Hidden;
                lblText1.Visibility = Visibility.Visible;
                cmbAddWeapons.Visibility = Visibility.Visible;
                lblText2.Visibility = Visibility.Visible;
                cmbAddEquipment.Visibility = Visibility.Visible;
                lblText3.Visibility = Visibility.Visible;
                cmbCurrentWeapon.Visibility = Visibility.Visible;
                lblText4.Visibility = Visibility.Visible;
                btnView.Visibility = Visibility.Visible;
                txtDescriptionView.Visibility = Visibility.Visible;
                txtDescriptionCharacter.Visibility = Visibility.Visible;
                btnDeleteMessages.Visibility = Visibility.Visible;
                lblCharacter.Visibility = Visibility.Visible;
                cmbMyCharacters.Visibility = Visibility.Hidden;
            }
            else if (Character.CreatedCharacters.Count == 0)
            {
                MessageBox.Show("Sorry, you haven't created any characters. Go back and create one to view its equipment", "¡Invalid application!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (cmbMyCharacters.Visibility == Visibility.Visible && cmbMyCharacters.Text == "")
            {
                MessageBox.Show("Please pick one of your characters that we've loaded for you", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                foreach (Character i in Character.CreatedCharacters)
                {
                    charactersName.Add(i.Name);
                }
                cmbMyCharacters.ItemsSource = charactersName;
                MessageBox.Show("All your characters have been loaded. Now, pick one of your characters and then press the button again to load their equipment", "¡We're almost done!", MessageBoxButton.OK, MessageBoxImage.Information);
                lblText0.Visibility = Visibility.Visible;
                cmbMyCharacters.Visibility = Visibility.Visible;
            }
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            txtDescriptionView.Visibility = Visibility.Hidden;
            txtDescriptionCharacter.Visibility = Visibility.Hidden;
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
                txtOutputInventory.Text = "Name: " + Character.CreatedCharacters[index].Name + "\n" + "Items: " + "\n";
                for (int i = 0; i < 8; i++)
                {
                    if (equipmentValue[i] != 0)
                    {
                        txtOutputInventory.Text += equipmentsName[i] + ", Number: " + equipmentValue[i] + "\n";
                    }
                }
                txtOutputInventory.Text += "Current Weapon: " + Character.CreatedCharacters[index].CurrentWeapon.Type() + "\n" + "The damage your current weapon got is: " + Character.CreatedCharacters[index].CurrentWeapon.attack() + "\n" + "\n";         
            }
            else
            {
                MessageBox.Show("Please pick one of your characters to view its equipment", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            cmbAddWeapons.Text = "";
            cmbAddEquipment.Text = "";
            cmbCurrentWeapon.Text = "";

        }
        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            Character.Change++;
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.mainFrame.NavigationService.Navigate(new MyCharacters());
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            txtDescriptionView.Visibility = Visibility.Hidden;
            txtDescriptionCharacter.Visibility = Visibility.Hidden;
            if (cmbAddWeapons.Text != "" || cmbAddEquipment.Text != "" || cmbCurrentWeapon.Text != "")
            {
                int index = cmbMyCharacters.SelectedIndex;
                switch (cmbAddWeapons.Text)
                {
                    case "Ax":
                        actualWeapons.Add("Ax");
                        Character.CreatedCharacters[index].Inventory.Add(new Ax());
                        break;
                    case "Boomerang":
                        actualWeapons.Add("Boomerang");
                        Character.CreatedCharacters[index].Inventory.Add(new Boomerang());
                        break;
                    case "Bow":
                        actualWeapons.Add("Bow");
                        Character.CreatedCharacters[index].Inventory.Add(new Bow());
                        break;
                    case "Sword":
                        actualWeapons.Add("Sword");
                        Character.CreatedCharacters[index].Inventory.Add(new Sword());
                        break;
                }
                switch (cmbAddEquipment.Text)
                {
                    case "Armor":
                        Character.CreatedCharacters[index].Inventory.Add(new Armor());
                        break;
                    case "Boot":
                        Character.CreatedCharacters[index].Inventory.Add(new Boot());
                        break;
                    case "Parachute":
                        Character.CreatedCharacters[index].Inventory.Add(new Parachute());
                        break;
                    case "Potion":
                        Character.CreatedCharacters[index].Inventory.Add(new Potion());
                        break;
                }
                foreach (IEquipment i in Character.CreatedCharacters[index].Inventory)
                {
                    if (i.Type() == cmbCurrentWeapon.Text)
                    {
                        Character.CreatedCharacters[index].CurrentWeapon = (Weapon)i;
                    }
                }
                MessageBox.Show("The character's information has been updated", "¡Successful application!", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbCurrentWeapon.Items.Clear();
                foreach (string i in actualWeapons)
                {
                    cmbCurrentWeapon.Items.Add(i);
                }
                cmbAddWeapons.Text = "";
                cmbAddEquipment.Text = "";
                cmbCurrentWeapon.Text = "";
                txtOutputInventory.Text = "";
            }
            else
            {
                MessageBox.Show("Please think at least one thing that you want to change of your character's equipment and then let us know it ", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnChangeCharacter_Click(object sender, RoutedEventArgs e)
        {
            txtDescriptionView.Visibility = Visibility.Hidden;
            txtDescriptionCharacter.Visibility = Visibility.Hidden;
            if (cmbMyCharacters.Text != "" && btnUpdate.Visibility == Visibility.Hidden)
            {
                int index = cmbMyCharacters.SelectedIndex;
                cmbCurrentWeapon.Items.Clear();
                foreach (IEquipment i in Character.CreatedCharacters[index].Inventory)
                {
                    foreach (string j in equipmentsName)
                    {
                        if (i.Type() == j && i.Type() != "Armor" && i.Type() != "Boot" && i.Type() != "Parachute" && i.Type() != "Potionr")
                        {
                            actualWeapons.Add(j);
                            cmbCurrentWeapon.Items.Add(j);
                        }
                    }
                }
                MessageBox.Show("The character has been changed", "¡Successful application!", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbAddWeapons.Text = "";
                cmbAddEquipment.Text = "";
                cmbCurrentWeapon.Text = "";
                cmbMyCharacters.Visibility = Visibility.Hidden;
                btnChangeCharacter.Margin = btnChangeCharacterTrial.Margin;

                lblCharacter.Visibility = Visibility.Visible;
                btnUpdate.Visibility = Visibility.Visible;
                lblText1.Visibility = Visibility.Visible;
                cmbAddWeapons.Visibility = Visibility.Visible;
                lblText2.Visibility = Visibility.Visible;
                cmbAddEquipment.Visibility = Visibility.Visible;
                lblText3.Visibility = Visibility.Visible;
                cmbCurrentWeapon.Visibility = Visibility.Visible;
                lblText4.Visibility = Visibility.Visible;
                btnView.Visibility = Visibility.Visible;
                btnDeleteMessages.Visibility = Visibility.Visible;
                lblCharacter.Visibility = Visibility.Visible;

            }
            else if (Character.CreatedCharacters.Count == 1)
            {
                MessageBox.Show("Sorry, you haven't created enough characters to change characters. Go back and create at least one more to use this functionality", "¡Invalid application!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (lblCharacter.Visibility == Visibility.Hidden && cmbMyCharacters.Visibility == Visibility.Visible)
            {
                MessageBox.Show("Please pick the character that you want to view its equipment", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                cmbMyCharacters.Visibility = Visibility.Visible;
                lblText0.Visibility = Visibility.Visible;
                btnChangeCharacter.Margin = btnSearch.Margin;

                lblCharacter.Visibility = Visibility.Hidden;
                btnUpdate.Visibility = Visibility.Hidden;
                lblText1.Visibility = Visibility.Hidden;
                cmbAddWeapons.Visibility = Visibility.Hidden;
                lblText2.Visibility = Visibility.Hidden;
                cmbAddEquipment.Visibility = Visibility.Hidden;
                lblText3.Visibility = Visibility.Hidden;
                cmbCurrentWeapon.Visibility = Visibility.Hidden;
                lblText4.Visibility = Visibility.Hidden;
                btnView.Visibility = Visibility.Hidden;
                btnDeleteMessages.Visibility = Visibility.Hidden;
                lblCharacter.Visibility = Visibility.Hidden;
                MessageBox.Show("You've decided to change character, nowpick the character you want", "¡We're almost done!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnDeleteMessages_Click(object sender, RoutedEventArgs e)
        {
            txtDescriptionCharacter.Text = "";
            txtDescriptionView.Text = "";
            btnDeleteMessages.Visibility = Visibility.Hidden;
        }
    }
}
