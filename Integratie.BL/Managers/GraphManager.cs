using Integratie.DAL;
using Integratie.DAL.Repositories;
using Integratie.DAL.Repositories.Interfaces;
using Integratie.Domain.Entities;
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
        FeedManager feedManager = new FeedManager();
        public void AddGraph(int userId, Graph graph)
        {
            
        }
        public Graph AddGraph(Graph graph)
        {
            return GraphRepo.AddGraph(graph);
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
            List<Graph> graphs = new List<Graph>();
            foreach(Graph g in GraphRepo.GetAllGraphs())
            {
                if (g.GraphType == GraphType.Single)
                {
                    graphs.Add(GetFilledSingleGraph(g));
                }
                if (g.GraphType == GraphType.Barchart)
                {
                    graphs.Add(GetFilledBarGraph(g));
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

        public Graph GetFilledSingleGraph(Graph graph)
        {
            graph.SingleValue = feedManager.GetFilteredFeeds(graph).Count();
            int countDays = 1;
            if (graph.CalcType == CalcType.AVG)
            {
                countDays = (int)(graph.EndDate - graph.StartDate).TotalDays;
            }
            graph.SingleValue = (int)graph.SingleValue / countDays;
            return graph;
        }
        public Graph GetFilledBarGraph(Graph graph)
        {
            graph.BarValues = new Dictionary<string, double>();
            List<Feed> feeds = feedManager.GetFilteredFeeds(graph).ToList();
            int countDays = 1;
            if (graph.CalcType == CalcType.AVG)
            {
                countDays = (int)(graph.EndDate - graph.StartDate).TotalDays;
            }
            if (graph.CompareSort == CompareSort.Politicians)
            {
                foreach(string s in graph.ComparePersons.Split(',').Select(s => s.Trim()))
                {
                    if(graph.CalcType == CalcType.Sum)
                    graph.BarValues.Add(s, feeds.Where(f => f.Persons.Contains(s)).Count());
                    if (graph.CalcType == CalcType.AVG)
                        graph.BarValues.Add(s, (int)feeds.Where(f => f.Persons.Contains(s)).Count()/countDays);
                }
            }
            return graph;
        }
    }
}
