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
        public object SubjectPropertyValue { get; set; }
        public SubjectProperty SubjectProperty { get; set; }
        public Operator Operator { get; set; }
        public int value { get; set; }
        public Subject Subject { get; set; }
    }
}
