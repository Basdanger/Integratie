using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Integratie.Domain.Entities.Subjects;
using Integratie.Domain.Entities;
namespace Integratie.MVC.Models
{
	public class PersonanFeeds
	{
        public Person persons { get; set; }
        public IEnumerable<Feed> feeds { get; set; }
    }
}