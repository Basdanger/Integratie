using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Content
{
    public class SiteContent
    {
        [Key]
        public String IdKey { get; set; }
        public String Value { get; set; }
        public SiteContent()
        {

        }
    }
}
