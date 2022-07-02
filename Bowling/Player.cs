using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    internal class Player
    {
        private string _name;
        private string[] _rolls;
        public Player(string name, string[] rolls)
        {
            _name = name;
            _rolls = rolls;
        }
        public string GetName { get { return _name; } }
        public string[] GetRolls { get { return _rolls; } }
        public string GetScore
        {
            get
            {
                int score = 0;
                for(int x=0;x<10;x++)
                {
                    int roll1 = int.Parse(_rolls[x*2]);
                    int roll2 = int.Parse(_rolls[x*2+1]);
                    score = score + roll1 + roll2;
                    if (roll1 == 10)
                        score = score + int.Parse(_rolls[x*2 + 2]) + int.Parse(_rolls[x*2 + 3]);
                    else
                    {
                        if (roll1 + roll2 == 10)
                            score += int.Parse(_rolls[x*2 + 2]);

                    }  

                }
                return score.ToString();
            }
        }



    }
}
