using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integratie.MVC.Models
{
    public class AlertUpdate
    {
        public int Id { get; set; }
        public bool Web { get; set; }
        public bool Mail { get; set; }
        public bool App { get; set; }
    }
}