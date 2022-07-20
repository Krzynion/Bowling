using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    internal class Frame
    {
        public Frame(string FirstRoll,String SecoundRoll,bool Strike, bool Spare)
        {
            this.Strike = Strike;
            this.Spare = Spare;
            this.FirstRoll = FirstRoll;
            this.SecoundRoll = SecoundRoll;
            int firstRollInt = 0;
            int secoundRollInt = 0;
            int.TryParse(FirstRoll, out firstRollInt);
            int.TryParse(SecoundRoll,out secoundRollInt);
            this.FramePoints = firstRollInt+secoundRollInt;
            
        }
        public string FirstRoll { get; }
        public string SecoundRoll { get;  }
        public bool Strike { get; }
        public bool Spare { get; }
        public int FramePoints { get; set; }
        
    }
}
