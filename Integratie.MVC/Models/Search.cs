using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integratie.MVC.Models
{
    public class Search
    {
        public IEnumerable<Person> persons { get; set; }
        public Person person { get; set; }
        public IEnumerable<String> organisaties { get; set; }
        public IEnumerable<String> steden { get; set; }
        public IEnumerable<Feed> feeds { get; set; }
        public IEnumerable<Feed> feedsByPerson { get; set; }
    }
}