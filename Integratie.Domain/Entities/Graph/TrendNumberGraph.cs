using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Graph
{
    public class TrendNumberGraph : NumberGraph
    {
        [NotMapped]
        public int Trend { get; set; }

        public TrendNumberGraph(Subject subject, NumberType type, Account account) :base(subject,type,account)
        {
        }
    }
    
}
