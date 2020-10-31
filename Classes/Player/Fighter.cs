using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy.Classes.Player
{
    public class Fighter : Character
    {
        public override string Taunt()
        {
            return "By my Lord";
        }
        public override string ShowCharacter()
        {
            return $"Remember my name {Name.ToUpper()} and My power {Level}";
        }
    }
}
