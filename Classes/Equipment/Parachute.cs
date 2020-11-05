using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Equipment
{
    public class Parachute : IDescribable, IEquipment
    {
        public string ShowInformation()
        {
            return "This is a super useful parachute";
        }

        public string Type()
        {
            return "Parachute";
        }
    }
}
