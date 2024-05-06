﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppPingPong.Temporary.AdditionalClasses
{
    public interface IPlayer
    {
        public Task Send();
        public void StartReceivingLoop();

        public void Run();

        public void Destroy();
    }
}
