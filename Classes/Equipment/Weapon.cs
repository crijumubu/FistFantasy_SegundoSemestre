using FirstFantasy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy.Classes.Equipment
{
    public abstract class Weapon : IDescribable
    {
        public string ShowInformation()
        {
            return "This is a weapon";
        }
    }
}
