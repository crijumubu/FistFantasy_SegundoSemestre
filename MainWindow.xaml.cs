using FirstFantasy_FinalExam.Classes.Player;
using FirstFantasy_FinalExam.Classes.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FirstFantasy_FinalExam.Interfaces;

namespace FirstFantasy_FinalExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Character character;
        Weapon weapon;
        IDescribable describable; //Se usa en especial para objetos como pociones, armadura, etc.

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string selectCharacter = cmbCharacter.Text;
            string selectWeapon = cmbWeapon.Text;
            string selectEquipment = cmbEqipment.Text;


            MessageBox.Show(selectCharacter);
            switch (cmbCharacter.Text)
            {
                case "Cleric":
                    character  = new Cleric();
                    break;
                case "Fighter":
                    character = new Fighter();
                    break;
                case "Rogue":
                    character = new Rogue();
                    break;
                case "Wizard":
                    character = new Wizard();
                    break;
            }
            character.Name = name;

            switch (selectWeapon)
            {
                case "Ax":
                    weapon = new Ax();
                    break;
                case "Sword":
                    weapon = new Sword();
                    break;
            }
            character.CurrentWeapon = selectWeapon;
            MessageBox.Show(weapon.attack());
            switch (selectEquipment)
            {
                case "Armor":
                    describable = new Armor();
                    break;
                case "Potion":
                    describable = new Potion();
                    break;
            }
            character.Inventory(describable);
        }
    }
}
