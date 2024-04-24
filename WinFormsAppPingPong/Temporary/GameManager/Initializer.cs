using PingPong.AdditionalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.GameManager
{
    internal class Initializer
    {
        public Initializer()
        {
            new ClientMoveHandler();
        }

    }
}
