using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain
{
    public class Organisatie : Subject
    {
        public String afkorting { get; set; }
        public DateTime oprichtingsjaar { get; set; }
        public String URL { get; set; }
        public Organisatie(int iD, string name) : base(iD, name)
        {
        }
    }
}
