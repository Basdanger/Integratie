using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Subjects
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String Name { get; set; }
        public int FeedCount { get; set; }
        public bool Trending { get; set; }

        public Subject()
        {

        }
        public Subject(string name)
        {
            Name = name;
        }
    }
}
