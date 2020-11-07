using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Equipment
{
    public class Boot : IEquipment
    {
        public int CapacityInMeters()
        {
            return 50;
        }

        public string Type()
        {
            return "Boot";
        }
    }
}
