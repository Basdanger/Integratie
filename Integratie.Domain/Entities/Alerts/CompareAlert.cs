using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.Domain.Entities.Subjects;
namespace Integratie.Domain.Entities.Alerts
{
    public class CompareAlert : Alert
    {
        public CompareAlert(Subject subjectA, Subject subjectB, Operator @operator)
        {
            SubjectA = subjectA;
            SubjectB = subjectB;
            Operator = @operator;
        }

        public CompareAlert()
        {
        }

        public Subject SubjectA { get; set; }
        public Subject SubjectB { get; set; }
        public Operator Operator { get; set; }
    }
}
