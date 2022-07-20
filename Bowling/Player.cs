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
        private List<Frame> _frames;
        public Player(string name, List<Frame> frames)
        {
            _name = name;
            _frames = frames;
           
        }
        public string GetName { get { return _name; } }
        public List<Frame> GetFrames { get { return _frames; } }
        public string Score()
        {
            int scoreInt = 0;
            for (int x = 0; x < 10; x++)
                scoreInt += _frames[x].FramePoints;
            return scoreInt.ToString();
        }



    }
}
