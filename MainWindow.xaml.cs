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
            if (name!="" || selectCharacter!="" || selectWeapon!="" || selectEquipment !="")
            {
                correctData = true;
            }
            else
            {
                MessageBox.Show("Haz olvidado llenar o sellecionar alguno de los campos. No podemos seguir sin estos, por favor completalos");
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
                createdCharacters[count].Name = name;
                createdCharacters[count].Type = selectCharacter;

                switch (selectWeapon)
                {
                    case "Ax":
                        createdWeapons.Add(new Ax());
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
                    case "Potion":
                        describable = new Potion();
                        break;
                }
                createdCharacters[count].AddToInventory(describable);
                Character.Createdcharacters.Add(createdCharacters[count]);
                count++;
                MessageBox.Show("El personaje se ha creado correctamente","¡Solictud exitosa!");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Visibility = Visibility.Visible;
            mainFrame.NavigationService.Navigate(new MyCharacters());
        }
    }
}
