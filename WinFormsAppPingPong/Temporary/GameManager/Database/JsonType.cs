using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppPingPong.Temporary.GameManager.Database
{
    internal class JsonType
    {
        public string Username1 { get; set; }
        public string Username2 { get; set;}

        public Point User1Position { get; set; }
        public Point User1Position2 { get;set; }

        public Point BallPosition { get; set; }

        public Point BallMovementVector { get; set; }

        public int User1Input {  get; set; }
        public int User2Input { get; set;}
    }
}
