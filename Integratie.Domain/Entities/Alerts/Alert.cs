using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Alerts
{
    public abstract class Alert
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlertID { get; set; }
        public bool Ring { get; set; } = false;
        public virtual Graph.Graph Graph { get; set; }
    }
}
