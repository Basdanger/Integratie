using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Alerts
{
    public abstract class Alert
    {
        public int ID { get; set; }
        public bool Ring { get; set; }
    }
}
