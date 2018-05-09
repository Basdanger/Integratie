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
        public CheckAlert(SubjectProperty subjectProperty, Operator @operator, double value, Subject subject)
        {
            SubjectProperty = subjectProperty;
            Operator = @operator;
            this.Value = value;
            Subject = subject;
        }

        public CheckAlert()
        {
        }

        public SubjectProperty SubjectProperty { get; set; }
        public Operator Operator { get; set; }
        public double Value { get; set; }
        public Subject Subject { get; set; }
    }
}
