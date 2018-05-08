using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities
{
    public class Account
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }

        public Account()
        {

        }
        public Account(int iD, string name, string mail)
        {
            ID = iD;
            Name = name;
            Mail = mail;
        }
    }
}
