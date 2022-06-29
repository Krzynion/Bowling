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
        public Frame(int FirstRoll, int SecoundRoll)
        {
            firstRoll = FirstRoll;
            if (FirstRoll == 10)
                strike = true;
            else
            {
                secoundRoll = SecoundRoll;
                if(FirstRoll+SecoundRoll == 10)
                    spare = true;
            }
        }

        public int GetFirstRoll
        {
            get { return firstRoll; }
        }
        public int GetSecoundRoll
        {
            get { return secoundRoll; }
        }
        public Boolean IsStrike
        {
            get { return strike; }
        }
        public Boolean IsSpare
        {
            get { return spare; }
        }
    }
}
