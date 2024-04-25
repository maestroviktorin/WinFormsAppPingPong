﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsAppPingPong.Temporary.GameManager;

namespace PingPong.GameManager
{
    public abstract class Entity: UpdateObject
    {
        public Point position;

        public double speed;

        public static double Distance(Point vector)
        {
            return Math.Sqrt(Math.Pow(vector.X, 2) +  Math.Pow(vector.Y, 2));
        }

        public abstract void Move();
    }
}
