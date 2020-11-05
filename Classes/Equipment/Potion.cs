using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Equipment
{
    public class Potion : IDescribable, IEquipment
    {
        private string recoveryValue = "10";
        public string GetRecoveryValue()
        {
            return recoveryValue;
        }
        public string ShowInformation()
        {
            return "This is a strange potion";
        }

        public string Type()
        {
            return "Potion";
        }
    }
}
