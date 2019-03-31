using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tron
{
    class Player
    {
        public List<Position> Line { get; set; }
        public Position MotorPos { get; set; }
        public bool Won { get; set; }
        public string Color { get; set; }
        public string Direction { get; set; }
        public Player(int startX, int startY, string ColorK, string dir)
        {
            Position start = new Position(startX, startY);
           Line = new List<Position>();
            Line.Add(start);
            Won = false;
            Color = ColorK;
            Direction = dir;
            MotorPos = new Position(startX, startY);
        }
    }
}
