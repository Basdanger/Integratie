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
        public BarChartType Type { get; set; }
        [NotMapped]
        public Dictionary<string,double> Values { get; set; }

        public BarChartGraph() : base(0, null)
        {
            Values = new Dictionary<string, double>();
        }
        public BarChartGraph(List<Subject> subjects, BarChartType type, Account account) : this()
        {

            Subjects = subjects;
            Type = type;
        }
    }
    public enum BarChartType
    {
        
        Count,
        Male,
        Female,
        Sentiment, //gemiddelde
        Age //gemiddelde

    }
}
