using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppPingPong.Temporary.GameManager.Database;

namespace PingPong.AdditionalClasses
{
    internal class MoveHandler
    {
        public static MoveHandler Instance { get; private set; }

        public MoveHandler()
        {
            if (Instance != null) throw new Exception("More than one instance");

            Instance = this;
        }

        public void Handle(char key)
        {
            if (key == (char)Keys.W)
            {
                PingPongData.Instance.HostInput = 1;
            }
            else if (key == (char)Keys.S)
            {
                PingPongData.Instance.HostInput = -1;
            }
            else
            {
                PingPongData.Instance.HostInput = 0;
            }
        }
    }
}
