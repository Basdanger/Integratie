using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain
{
    public class Theme : Subject
    {
        public List<String> termen { get; set; }

        public Theme(int iD, string name) : base(iD, name)
        {
        }
    }
}
