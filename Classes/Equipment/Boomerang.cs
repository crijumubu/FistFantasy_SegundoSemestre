using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Equipment
{
    public class Boomerang : Weapon
    {
        public override string attack()
        {
            int damage = 13;
            Random random = new Random();
            int total = damage + random.Next(1, 9);
            return total.ToString();
        }

        public override string Type()
        {
            return "Boomerang";
        }
    }
}
