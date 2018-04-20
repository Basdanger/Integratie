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
        public double ID { get; set; }
        public Profile Profile { get; set; }
        public List<String> Words { get; set; }
        public List<double> Sentiment { get; set; }
        public String Source { get; set; }
        public List<String> Hashtags { get; set; }
        public List<String> Themes { get; set; }
        public List<String> Persons { get; set; }
        public List<String> Urls { get; set; }
        public DateTime Date { get; set; }
        public List<String> Mentions { get; set; }
        public dynamic Geo { get; set; }
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

        public Feed(double id, Profile profile ,List<String> words, List<double> sentiment,
                    String source, List<String> hashtags, List<String> themes, 
                    List<String> persons, List<String> urls, DateTime date, 
                    List<String> mentions, dynamic geo, bool retweet)
        {
            ID = id;
            Profile = profile;
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
        m, f
    }

    public class Profile
    {
        public Gender Gender { get; set; }
        public String Age { get; set; }
        public String Education { get; set; }
        public String Language { get; set; }
        public String Personality { get; set; }


        public Profile()
        {

        }
        public Profile(Gender gender, String age, String education, String language, String personality)
        {
            Gender = gender;
            Age = age;
            Education = education;
            Language = language;
            Personality = personality;
        }
    }
}
