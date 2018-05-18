using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Subjects
{
    public class TermMention
    {
        public int Id { get; set; }
        public String Term { get; set; }
        public int Count { get; set; }

        public TermMention(string term, int count)
        {
            Term = term;
            Count = count;
        }
    }
}
