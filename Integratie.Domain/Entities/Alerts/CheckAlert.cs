using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.Domain.Entities.Subjects;

namespace Integratie.Domain.Entities.Alerts
{
    //Basic Alert
    public class CheckAlert : Alert
    {
        public CheckAlert(object subjectPropertyValue, SubjectProperty subjectProperty, Operator @operator, double value, Subject subject)
        {
            SubjectPropertyValue = subjectPropertyValue;
            SubjectProperty = subjectProperty;
            Operator = @operator;
            this.Value = value;
            Subject = subject;
        }

        public object SubjectPropertyValue { get; set; }
        public SubjectProperty SubjectProperty { get; set; }
        public Operator Operator { get; set; }
        public double Value { get; set; }
        public Subject Subject { get; set; }
    }
}
