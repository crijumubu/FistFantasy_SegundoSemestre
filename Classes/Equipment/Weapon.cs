using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Equipment
{
    public abstract class Weapon : IDescribable, IEquipment
    {
        public abstract string attack();
        public abstract string Type();
        public string ShowInformation()
        {
            return "This is a weapon";
        }
    }
}
