using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Alerts
{
    public class CompareAlert : Alert
    {
        public Subject SubjectA { get; set; }
        public Subject SubjectB { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }


        public int MyProperty { get; set; }
    }
}
