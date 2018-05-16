using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Alerts
{
    public class UserAlert
    {
        public int ID { get; set; }
        public virtual Account Account { get; set; }
        public virtual Alert Alert { get; set; }
        public bool Show { get; set; }
        public bool Web { get; set; }
        public bool Mail { get; set; }
        public bool App { get; set; }

        public UserAlert(Account account, Alert alert, bool web, bool mail, bool app)
        {
            Account = account;
            Alert = alert;
            Web = web;
            Mail = mail;
            App = app;
            Show = false;
        }

        public UserAlert()
        {
        }
    }
}
