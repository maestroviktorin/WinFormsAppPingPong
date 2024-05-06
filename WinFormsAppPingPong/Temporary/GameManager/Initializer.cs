using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsAppPingPong.Temporary.GameManager;
using WinFormsAppPingPong.Temporary.GameManager.Database;

namespace PingPong.GameManager
{
    internal class Initializer
    {
        public Initializer()
        {
            new PingPongData();
        }

    }
}
