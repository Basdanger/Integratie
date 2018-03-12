using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain
{
    public class Subject
    {
        public String Name { get; set; }
        public List<Feed> Feeds { get; set; }
    }
}
