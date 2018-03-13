using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Alerts
{
    //Basic Alert
    public class CheckAlert : Alert
    {
        public Subject Subject { get; set; }

        public int MyProperty { get; set; }
        public override void Check()
        {

        }
    }
}
