using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Subjects
{
    public class Story
    {
        public int Id { get; set; }
        public String StoryString { get; set; }
        public String Titel { get; set; }
        public String Link { get; set; }
    }
}
