using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppPingPong.Temporary.GameManager.Events
{
    public class PingPongEvents
    {
        public static Action<PlayerJoinEvent> OnPlayerJoin = (PlayerJoinEvent p) => { };

        public static Action OnBallTouchPlayer = () => { };        
    }

    public class PlayerJoinEvent
    {
        public EndPoint playerIP;
        public PlayerJoinEvent(EndPoint ep)
        {
            this.playerIP = ep;
        }
    }
}
