using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppPingPong.Temporary.GameManager
{
    public abstract class UpdateObject
    {
        public static List<UpdateObject> objects { get; } = new List<UpdateObject>();
        public UpdateObject()
        {
            objects.Add(this);
        }

        public virtual void Update() { }

    }
}
