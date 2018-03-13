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
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public Feed(DateTime date, int sentiment, int age, Gender gender)
        {
            Date = date;
            Sentiment = sentiment;
            Age = age;
            Gender = gender;
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
