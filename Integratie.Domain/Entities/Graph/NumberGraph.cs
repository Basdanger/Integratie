using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Graph
{
    public class NumberGraph : Graph
    {
        public Subject Subject { get; set; }
        public NumberType Type { get; set; }
        [NotMapped]
        public int Value { get; set; }

        public NumberGraph(Subject subject, NumberType type, Account account) :base(account)
        {
            Subject = subject;
            Type = type;
        }
    }
    public enum NumberType
    {
        TWEETS,
        POSTWEETS,
        NEGTWEETS,
        MALETWEETS,
        FEMALETWEETS,
        MENTIONS
    }
}
