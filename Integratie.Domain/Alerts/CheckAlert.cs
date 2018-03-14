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
        public CheckAlert(object subjectPropertyValue, SubjectProperty subjectProperty, Operator @operator, int value, Subject subject)
        {
            SubjectPropertyValue = subjectPropertyValue;
            SubjectProperty = subjectProperty;
            Operator = @operator;
            this.value = value;
            Subject = subject;
        }
        public CheckAlert()
        {

        }

        public object SubjectPropertyValue { get; set; }
        public SubjectProperty SubjectProperty { get; set; }
        public Operator Operator { get; set; }
        public int value { get; set; }
        public Subject Subject { get; set; }
    }
}
