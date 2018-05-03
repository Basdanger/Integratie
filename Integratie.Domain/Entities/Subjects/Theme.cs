using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Subjects
{
    public class Theme : Subject
    {
        public List<String> Terms { get; set; }

        public Theme()
        {
        }

        public Theme(int iD, string name) : base(iD, name)
        {
        }
    }
}
