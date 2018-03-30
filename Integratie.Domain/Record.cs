using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain
{
    public class Record
    {
        public List<String> hashtags { get; set; }
        public List<String> words { get; set; }
        public DateTime date { get; set; }
        public List<string> politician { get; set; }
        public string geo { get; set; }
        public object id { get; set; }
        public string user_id { get; set; }
        public List<double> sentiment { get; set; }
        public bool retweet { get; set; }
        public string source { get; set; }
        public List<object> urls { get; set; }
        public List<object> mentions { get; set; }

        public override string ToString()
        {
            return id + " " + user_id + " " + date + " " + source;
        }

    }
    public class RootObject
    {
        public List<Record> records { get; set; }
    }
}
