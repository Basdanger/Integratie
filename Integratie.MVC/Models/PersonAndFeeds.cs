using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integratie.MVC.Models
{
    public class PersonAndFeeds
    {
        public Person person { get; set; }
        public IEnumerable<Feed> feeds { get; set; }
    }
}