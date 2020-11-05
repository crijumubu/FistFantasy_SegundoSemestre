using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Equipment
{
    class Ax : Weapon, IEquipment
    {
        public override string attack()
        {
            int damage= 10;
            Random random = new Random();
            int total = damage + random.Next(1, 9);
            return total.ToString();
        }

        public string Type()
        {
            return "Ax";
        }
    }
}
