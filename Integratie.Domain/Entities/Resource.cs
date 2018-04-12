using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities
{
    public class Resource
    {
        public string Culture { get; set; }
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }

        public Resource(string culture, string name, string value)
        {
            Culture = culture;
            Name = name;
            Value = value;
        }
    }
}
