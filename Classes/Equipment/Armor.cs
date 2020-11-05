using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Equipment
{
    class Armor : IDescribable, IEquipment
    {
        private string armorValue = "8";
        public string GetarmorValue()
        {
            return armorValue;
        }
        public string ShowInformation()
        {
            return "This is a armor";
        }

        public string Type()
        {
            return "Armor";
        }
    }
}
