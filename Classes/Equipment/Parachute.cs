using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Equipment
{
    public class Parachute :  IEquipment
    {
        public int FlightTimeInS()
        {
            return 9;
        }

        public string Type()
        {
            return "Parachute";
        }
    }
}
