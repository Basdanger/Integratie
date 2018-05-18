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
        public String Words { get; set; }
        public String Sentiment { get; set; }
        public String Source { get; set; }
        public String Hashtags { get; set; }
        public String Themes { get; set; }
        public String Persons { get; set; }
        public String Urls { get; set; }
        public DateTime Date { get; set; }
        public String Mentions { get; set; }
        public String Geo { get; set; }
        public bool Retweet { get; set; }
        
        public Feed()
        {

        }

        public Feed(Profile profile, String words, String sentiment,
                    String source, String hashtags, double id, String themes, 
                    String persons, String urls, DateTime date, 
                    String mentions, String geo, bool retweet)
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

        public List<string> GetWords() {
            return Words.Split(',').Select(s => s.Trim()).ToList();
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
