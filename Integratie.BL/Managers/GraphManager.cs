using Integratie.DAL;
using Integratie.DAL.Repositories;
using Integratie.DAL.Repositories.Interfaces;
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
        public List<Graph> Update(List<Graph> graphs)
        {
            foreach(Graph GG in graphs)
            {
                GraphRepo.Update(GG);
            }
            return GraphRepo.GetAllGraphs();
        }

        public Graph GetGraphbyId(int id)
        {
            return GraphRepo.GetGraphById(id);
        }

        public BarChartGraph GetBarChartGraph(int id)
        {
            BarChartGraph graph = (BarChartGraph)GraphRepo.GetGraphById(id);
            FeedManager feedManager = new FeedManager();
            //graph.Subjects.ForEach(s => graph.Values.Add(s.Name, feedManager.GetPersonFeeds(s.Name).Count()));
            graph.Values.Add("Bart", 50);
            graph.Values.Add("Kris", 100);
            graph.Values.Add("Maggie", 66);
            return graph;
        }

        public PieGraph GetPieGraph(int id)
        {
            PieGraph graph = (PieGraph)GraphRepo.GetGraphById(id);
            FeedManager feedManager = new FeedManager();
            graph.Values.Add("Male", feedManager.GetPersonFeedsGender(graph.Subject.Name, Domain.Entities.Gender.m).Count());
            graph.Values.Add("Female", feedManager.GetPersonFeedsGender(graph.Subject.Name, Domain.Entities.Gender.f).Count());
            return graph;
        }
    }
}
