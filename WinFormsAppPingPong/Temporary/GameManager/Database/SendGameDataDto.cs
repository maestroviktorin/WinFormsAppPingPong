using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppPingPong.Temporary.GameManager.Database
{
    public class SendGameDataDto
    {
        public Point HostPosition { get; set; }
        public Point ClientPosition { get; set; }
        public Point BallPosition { get; set; }
        public int HostScore { get; set; }
        public int ClientScore { get; set; }
    }
}
