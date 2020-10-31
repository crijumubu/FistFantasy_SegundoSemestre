using System;
using System.Collections.Generic;
using System.Text;

namespace FirstFantasy_FinalExam.Classes.Player
{
    public class Wizard : Character
    {
        private int mp;

        public int Mp { get => mp; set => mp = value; }

        public override string Taunt()
        {
            return "By the Magic";
        }
        public string CastSpell()
        {
            return "KAAAA BUMM";
        }
    }
}
