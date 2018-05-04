using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.Domain.Entities.Graph;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integratie.Domain.Entities.Dashboard
{
    public class DashboardItem
    {
        public int Id { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public int X_Size { get; set; }
        public int Y_Size { get; set; }
        public Graph.Graph Graph { get; set; }
        [NotMapped]
        public int GridId { get; set; }
        [NotMapped]
        public int GraphId { get; set; }

        public DashboardItem()
        {

        }

        public DashboardItem(int id, int column, int row, int x_Size, int y_Size, Graph.Graph graph)
        {
            Id = id;
            Column = column;
            Row = row;
            X_Size = x_Size;
            Y_Size = y_Size;
            Graph = graph;
        }
    }
}
