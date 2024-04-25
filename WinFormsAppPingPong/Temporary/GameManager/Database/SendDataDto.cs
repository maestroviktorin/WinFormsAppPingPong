using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppPingPong.Temporary.GameManager.Database
{
    public class SendDataDto
    {
        public string Nickname { get; set; }
        public Point PlayerPosition { get; set; }
        public Point? BallPosition { get; set; }
        public Point? BallMovementVector { get; set; }
        public int Input {  get; set; }
    }
}
