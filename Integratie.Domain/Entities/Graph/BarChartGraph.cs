using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Graph
{
    public class BarChartGraph : Graph
    {
        public List<Subject> Subjects { get; set; }
        public BarChartType Type { get; set; }
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
