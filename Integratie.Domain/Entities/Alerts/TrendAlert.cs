using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Alerts
{
    public class TrendAlert : Alert
    {
        public TrendAlert(Subject subject)
        {
            Subject = subject;
        }

        public TrendAlert()
        {
        }

        public Subject Subject { get; set; }
    }
}
