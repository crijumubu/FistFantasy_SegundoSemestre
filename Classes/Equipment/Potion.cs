using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Equipment
{
    public class Potion :  IEquipment
    {
        private string recoveryValue = "10";
        public string GetRecoveryValue()
        {
            return recoveryValue;
        }
        public string Type()
        {
            return "Potion";
        }
    }
}
