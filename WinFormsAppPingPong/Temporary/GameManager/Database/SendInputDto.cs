using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WinFormsAppPingPong.Temporary.GameManager.Database
{
    public class SendInputDto
    {
        public bool InputUp {  get; set; }
        public bool InputDown {  get; set; }
    }
}
