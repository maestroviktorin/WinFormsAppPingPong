using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.GameManager
{
    internal class Player : Entity
    {
        public int Score { get; }
        public string Name { get; }

        public Player(int score, string name)
        {
            Score = score;
            Name = name;
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
