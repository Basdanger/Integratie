using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities
{
    public class Feed
    {
        [Key]
        public int ID { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public String Education { get; set; }
        public String Language { get; set; }
        public String Personality { get; set; }
        public List<String> Words { get; set; }
        public List<double> Sentiment { get; set; }
        public List<String> Source { get; set; }
        public List<String> Hashtags { get; set; }
        public List<String> Themes { get; set; }
        public List<String> Persons { get; set; }
        public List<String> Urls { get; set; }
        public DateTime Date { get; set; }
        public List<String> Mentions { get; set; }
        public List<double> Geo { get; set; }
        public bool Retweet { get; set; }

        public Feed(DateTime date, List<double> sentiment)
        {
            Date = date;
            Sentiment = sentiment;
        }
        public Feed(DateTime date)
        {
            Date = date;
        }
        public Feed()
        {

        }

        public Feed(int id, Gender gender, int age, String education, String language, 
                    String personality, List<String> words, List<double> sentiment,
                    List<String> source, List<String> hashtags, List<String> themes, 
                    List<String> persons, List<String> urls, DateTime date, 
                    List<String> mentions, List<double> geo, bool retweet)
        {
            ID = id;
            Gender = gender;
            Age = age;
            Education = education;
            Language = Language;
            Personality = personality;
            Words = words;
            Date = date;
            Source = source;
            Sentiment = sentiment;
            Hashtags = hashtags;
            Mentions = mentions;
            Urls = urls;
            Themes = themes;
            Persons = persons;
            Geo = geo;
            Retweet = retweet;
        }

        

    }
    public enum Gender
    {
        male, female
    }

    public class RootObject
    {
        public List<Feed> Feeds { get; set; }
    }
}
