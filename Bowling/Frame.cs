using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    internal class Frame
    {
        private int firstRoll;
        private int secoundRoll;
        private Boolean strike;
        private Boolean spare;
        public Frame() { }
        public int FirstRoll
        {
            get { return firstRoll; }
            set
            {
                firstRoll = value;
                StrikeSpareCheck();
            }
        }
        public int SecoundRoll
        {
            get { return secoundRoll; }
            set
            {
                secoundRoll = value;
                StrikeSpareCheck();  
            }
        }
        public Boolean IsStrike
        {
            get { return strike; }
        }
        public Boolean IsSpare
        {
            get { return spare; }
        }
        private void StrikeSpareCheck()
        {
            strike = false;
            spare = false;
            if (firstRoll == 10)
                strike = true;
            else
            {
                if(firstRoll+ secoundRoll == 10)
                    spare=true;
            }
        }
    }
}
