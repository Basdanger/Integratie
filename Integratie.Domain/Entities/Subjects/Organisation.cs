using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Subjects
{
    public class Organisation : Subject
    {
        public Organisation()
        {

        }
        public Organisation(int iD, string name) : base(iD, name)
        {

        }
    }
}
