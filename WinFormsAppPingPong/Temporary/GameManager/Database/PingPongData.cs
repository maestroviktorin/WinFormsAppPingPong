using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppPingPong.Temporary.GameManager.Database
{
    internal class PingPongData
    {
        public static PingPongData Instance = null;
        public PingPongData()
        {
            if (Instance != null) throw new Exception("More than one instance");

            Instance = this;
        }
        public string HostName { get; set; } = "p1";
        public string ClientName { get; set; } = "p2";

        public Point HostPosition { get; set; }
        public Point ClientPosition { get;set; }

        public Point BallPosition { get; set; }

        public bool HostInputUp { get; set; }
        public bool HostInputDown { get; set; } 
        public bool ClientInputUp { get; set; } 
        public bool ClientInputDown { get; set; } 

        public int HostScore { get; set; }
        public int ClientScore { get; set; }
    }
}
