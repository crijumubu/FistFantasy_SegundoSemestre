using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Player
{
    public abstract class Character : IDescribable
    {
        private string name;
        private int level;
        private int experience;
        private string currentWeapon;
        private List<IDescribable> inventory;

        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }
        public int Experience { get => experience; set => experience = value; }
        public string CurrentWeapon { get => currentWeapon; set => currentWeapon = value; }

        public abstract string Taunt();
        public virtual string ShowCharacter()
        {
            return $"Name: {name} Level: {level} XP: {experience}";
        }
        public string ShowInformation()
        {
            return "This is a level " + level + " character";
        }
        public void Inventory(IDescribable item) //Revisar este método
        {
            inventory.Add(item); 
        }
    }
}   