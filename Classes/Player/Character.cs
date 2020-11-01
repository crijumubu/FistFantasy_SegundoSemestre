using FirstFantasy_FinalExam.Classes.Equipment;
using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Player
{
    public abstract class Character : IDescribable
    {
        private string type;
        private string name;
        private int level = 1;
        private int experience = 1;
        private Weapon currentWeapon;
        private List<IDescribable> inventory = new List<IDescribable>();
        private static List<Character> createdcharacters = new List<Character>();

        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }
        public int Experience { get => experience; set => experience = value; }
        public Weapon CurrentWeapon { get => currentWeapon; set => currentWeapon = value; }
        public List<IDescribable> Inventory { get => inventory; set => inventory = value; }
        public string Type { get => type; set => type = value; }
        public static List<Character> Createdcharacters { get => createdcharacters; set => createdcharacters = value; }

        public abstract string Taunt();
        public virtual string ShowCharacter()
        {
            return $"Name: {name} Level: {level} XP: {experience}";
        }
        public string ShowInformation()
        {
            return "This is a level " + level + " character";
        }
        public void AddToInventory(IDescribable item)
        {
            inventory.Add(item);
        }
    }
}