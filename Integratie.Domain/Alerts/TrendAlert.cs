using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Alerts
{
    public class TrendAlert : Alert
    {
        public TrendAlert(Subject subject)
        {
            Subject = subject;
        }

        public Subject Subject { get; set; }
    }
}
