using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Graph
{
    public class BarChartGraph : Graph
    {
        public List<Subject> Subjects { get; set; }
        public Period Period { get; set; }
        [NotMapped]
        public Dictionary<string,double> Values { get; set; }

        public BarChartGraph(List<Subject> list, Account a1) : base(null)
        {
            Values = new Dictionary<string, double>();
        }

        public BarChartGraph()
        {
        }

        public BarChartGraph(List<Subject> subjects, Period period, Account account) : base(account)
        {
            Subjects = subjects;
            Period = period;
        }
    }
    public enum Period
    {
        DAY,
        WEEK,
        MONTH,
        TOTAL
    }
}
