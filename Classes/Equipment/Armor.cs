using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Equipment
{
    class Armor : IEquipment
    {
        private string armorValue = "8";
        public string GetarmorValue()
        {
            return armorValue;
        }
        public string Type()
        {
            return "Armor";
        }
    }
}
