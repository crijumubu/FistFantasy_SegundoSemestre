using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Equipment
{
    public class Parachute : IDescribable
    {
        public string ShowInformation()
        {
            return "This is a super useful parachute";
        }
    }
}
