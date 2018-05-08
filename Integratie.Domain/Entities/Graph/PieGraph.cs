using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Graph
{
    public class PieGraph : Graph
    {
        public Subject Subject { get; set; }
        public PieType PieType { get; set; }
        [NotMapped]
        public Dictionary<string, double> Values { get; set; }

        public PieGraph() : base(0, null)
        {
            Values = new Dictionary<string, double>();
        }
        public PieGraph(Subject subject, Account account) : this()
        {
            Subject = subject;
        }
        public PieGraph(Subject subject, PieType pieType, Account account) : base(account)
        {
            Subject = subject;
            PieType = pieType;
        }
    }
    public enum PieType
    {
        GENDER,
        POSNEG,
        AGE
    }
}
