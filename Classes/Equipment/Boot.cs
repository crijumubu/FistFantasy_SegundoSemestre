using FirstFantasy_FinalExam.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Equipment
{
    public class Boot : IDescribable
    {
        public string ShowInformation()
        {
            return "This is a boot. You gonna run super fast";
        }
    }
}
