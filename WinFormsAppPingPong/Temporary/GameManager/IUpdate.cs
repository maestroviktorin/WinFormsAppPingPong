using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppPingPong.Temporary.GameManager
{
    public interface IUpdate
    {
        public static List<IUpdate> Updates { get; } = new List<IUpdate>();

        void Update();
    }
}
