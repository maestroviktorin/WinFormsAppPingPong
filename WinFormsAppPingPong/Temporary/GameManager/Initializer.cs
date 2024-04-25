using PingPong.AdditionalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsAppPingPong.Temporary.GameManager;

namespace PingPong.GameManager
{
    internal class Initializer
    {
        public Initializer()
        {
            new ClientMoveHandler();
        }

        Type[] GetUpdates()
        {
            var type = typeof(IUpdate);
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .Select(a => a.GetTypes()
                            .Where(p => type.IsAssignableFrom(p)));
        }

    }
}
