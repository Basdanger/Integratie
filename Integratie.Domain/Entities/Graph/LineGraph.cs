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
        public List<Subject> Subjects { get; set; }
        public Period Period { get; set; }
    }
}
