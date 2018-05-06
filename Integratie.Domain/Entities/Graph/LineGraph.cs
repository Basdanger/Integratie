using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Graph
{
    public class LineGraph : Graph
    {
        public Subject Subject { get; set; }
        public Period period { get; set; }
    }

    public LineGraph(Subject subject) 
    {
        Subject Subject = subject;
        period = Period.DAY;
    }
    public enum Period
    {
        DAY,
        WEEK
    }
}
