using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Graph
{
    public abstract class Graph
    {
        public int GraphId { get; set; }
        public Account Account { get; set; }

        public Graph(int graphId, Account account)
        {
            GraphId = graphId;
            Account = account;
        }
        public Graph()
        {

        }
       
    }
}
