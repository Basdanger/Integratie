using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Alerts
{
    public abstract class Alert
    {
   
        public virtual bool ring()
        {
            return false;
        }
    }
}
