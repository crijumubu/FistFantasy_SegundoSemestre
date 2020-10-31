using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Equipment
{
    class Ax : Weapon, IDescribable
    {
        public override string attack()
        {
            int damage= 15;
            Random random = new Random();
            int total = damage + random.Next(1, 9);
            return total.ToString();
        }
    }
}
