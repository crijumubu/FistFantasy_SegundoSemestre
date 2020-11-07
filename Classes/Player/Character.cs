using FirstFantasy_FinalExam.Classes.Equipment;
using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Player
{
    public abstract class Character
    {
        private string id;
        private string type;
        private string name;
        private string level = "1";
        private string experience = "1";
        private static int change = 0;
        private Weapon currentWeapon;
        private List<IEquipment> inventory = new List<IEquipment>();
        private static List<Character> createdCharacters = new List<Character>();

        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Level { get => level; set => level = value; }
        public string Experience { get => experience; set => experience = value; }
        public Weapon CurrentWeapon { get => currentWeapon; set => currentWeapon = value; }
        public List<IEquipment> Inventory { get => inventory; set => inventory = value; }
        public string Type { get => type; set => type = value; }
        public static List<Character> CreatedCharacters { get => createdCharacters; set => createdCharacters = value; }
        public static int Change { get => change; set => change = value; }

        public abstract string Taunt();
        public virtual string ShowCharacter()
        {
            return $"Name: {name} Level: {level} XP: {experience}";
        }
    }
}