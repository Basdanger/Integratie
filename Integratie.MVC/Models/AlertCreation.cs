using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integratie.MVC.Models
{
    public class AlertCreation
    {
        public string AlertType { get; set; }
        public string Subject { get; set; }
        public bool Web { get; set; }
        public bool Mail { get; set; }
        public bool App { get; set; }
        public string SubjectB { get; set; }
        public string Compare { get; set; }
        public string SubjectProperty { get; set; }
        public int Value { get; set; }
    }
}