using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain
{
    public class Feed
    {
        public DateTime Date { get; set; }
        public int Sentiment { get; set; }
        public bool Repost { get; set; }

        public Feed(DateTime date, int sentiment)
        {
            Date = date;
            Sentiment = sentiment;
        }
        public Feed()
        {

        }

    }
    public enum Gender
    {
        male, female
    }
}
