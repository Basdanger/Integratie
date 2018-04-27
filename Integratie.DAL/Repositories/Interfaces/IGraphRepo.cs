using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.Repositories.Interfaces
{
    public interface IGraphRepo
    {
        List<Graph> GetAllGraphs();
        Graph GetGraphById(int Id);
        List<Graph> GetGraphsByUserId(int Id);
        void AddGraph(Graph graph);
        int GetTotalCount();
    }
}
