using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Alerts
{
    public class SentimentAlert : Alert
    {
        public SubjectProperty SubjectProperty { get; set; }
        public Operator Operator { get; set; }
        public int Value { get; set; }
        public Subject Subject { get; set; }

        public SentimentAlert(SubjectProperty subjectProperty, Operator @operator, int value, Subject subject)
        {
            SubjectProperty = subjectProperty;
            Operator = @operator;
            this.Value = value;
            Subject = subject;
        }

        public SentimentAlert()
        {
        }
    }
}
