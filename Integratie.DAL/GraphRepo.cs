using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.Domain.Entities.Graph;
using Integratie.DAL.EF;

namespace Integratie.DAL
{
    public class GraphRepo : IGraphRepo
    {
        DashBoardDbContext context = new DashBoardDbContext();
        public void AddGraph(Graph graph)
        {
            throw new NotImplementedException();
        }

        public List<Graph> GetAllGraphs()
        {
            return context.Graphs.ToList();
        }

        public Graph GetGraphById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Graph> GetGraphsByUserId(int Id)
        {
            throw new NotImplementedException();
        }
        public int GetTotalCount()
        {
            return context.Graphs.Count();
        }
    }
}
