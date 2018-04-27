using Integratie.DAL;
using Integratie.Domain.Entities.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.BL.Managers
{
    public class GraphManager
    {
        IGraphRepo GraphRepo = new GraphRepo();
        public void AddGraph(int userId, Graph graph)
        {
            
        }
        public int GetGraphCount()
        {

            return GraphRepo.GetTotalCount();
        }
        public List<Graph> GetAllGraphs()
        {
            return GraphRepo.GetAllGraphs();
        }
        public List<Graph> GetAllFilledGraphs()
        {
            List<Graph> graphs = GraphRepo.GetAllGraphs();
            foreach(Graph g in graphs)
            {
                if (g.GetType() == typeof(BarChartGraph))
                {
                    BarChartGraph bcg = (BarChartGraph)g;
                    bcg.Values.Add("Test1", 20);
                    bcg.Values.Add("Test2", 10);
                    bcg.Values.Add("Test3", 15);


                }
            }
            return graphs;
        }
    }
}
