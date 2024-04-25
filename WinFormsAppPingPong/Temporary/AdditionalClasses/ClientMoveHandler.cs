using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong.AdditionalClasses
{
    internal class ClientMoveHandler
    {
        public static ClientMoveHandler? Instance { get; private set; }

        public int Y = 0;

        public ClientMoveHandler()
        {
            if (Instance != null) throw new Exception("More than one instance");

            Instance = this;
        }

        public void Handle(char key)
        {
            if (key == (char)Keys.W)
            {
                Y = 1;
            }
            else if (key == (char)Keys.S)
            {
                Y = -1;
            }
            else
            {
                Y = 0;
            }
        }
    }
}
