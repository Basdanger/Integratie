﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.Domain.Entities.Graph;
using Integratie.DAL.EF;
using Integratie.DAL.Repositories.Interfaces;

namespace Integratie.DAL.Repositories
{
    public class GraphRepo : IGraphRepo
    {
        private readonly DashBoardDbContext context;

        public GraphRepo()
        {
            context = new DashBoardDbContext();
        }

        public GraphRepo(UnitOfWork unitOfWork)
        {
            context = unitOfWork.Context;
        }

        public Graph AddGraph(Graph graph)
        {

            Graph g = context.Graphs.Add(graph);
            context.SaveChanges();
            return g;
        }

        public List<Graph> GetAllGraphs()
        {
                return context.Graphs.ToList();
        }

        public Graph GetGraphById(int Id)
        {
            return context.Graphs.Find(Id);
        }

        public List<Graph> GetGraphsByUserId(int Id)
        {
            throw new NotImplementedException();
        }
        public int GetTotalCount()
        {
            try {
                return context.Graphs.Count();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public Graph Update(Graph graph)
        {
            Graph gr = context.Graphs.Where(g => g.GraphId == graph.GraphId).First();
            context.Graphs.Remove(gr);
            context.Graphs.Add(graph);
            context.SaveChanges();
            return context.Graphs.Where(g => g.GraphId == graph.GraphId).First();
        }

    }
}
