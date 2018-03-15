using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Alerts
{
    public class CompareAlert : Alert
    {
        public CompareAlert(Subject subjectA, Subject subjectB, Operator @operator)
        {
            SubjectA = subjectA;
            SubjectB = subjectB;
            Operator = @operator;
        }

        public Subject SubjectA { get; set; }
        public Subject SubjectB { get; set; }
        public Operator Operator { get; set; }


        public int MyProperty { get; set; }
    }
}
