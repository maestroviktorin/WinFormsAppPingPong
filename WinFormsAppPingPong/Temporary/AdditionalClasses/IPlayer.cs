using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppPingPong.Temporary.AdditionalClasses
{
    internal interface IPlayer
    {
        public Task Send();
        public void StartReceivingLoop();
    }
}
