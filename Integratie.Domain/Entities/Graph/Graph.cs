using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Graph
{
    public class Graph
    {
        [Key]
        public int GraphId { get; set; }
        public Account Account { get; set; }
        public GraphType GraphType { get; set; }
        public CalcType CalcType { get; set; }

        //COMPARE
        public CompareSort CompareSort { get; set; }
        public String ComparePersons { get; set; }

        //TIME
        public PeriodSort PeriodSort { get; set; }
        private DateTime _StartDate;
        private DateTime _EndDate;
        public DateTime StartDate {
            get {
                if (PeriodSort == PeriodSort.Fixed) return _StartDate;
                else return DateTime.Now.AddDays(PeriodLength * -1);
            }
            set { _StartDate = value; }
        }
        public DateTime EndDate {
            get
            {
                if (PeriodSort == PeriodSort.Fixed) return _EndDate;
                else return DateTime.Now;

            }
            set { _EndDate = value; }
        }
        public int PeriodLength { get; set; }

        //INTERVAL
        public double StartInterval { get; set; }
        public double EndInterval { get; set; }
        public double IntervalSize { get; set; }

        //FILTERS
        public AgeFilter AgeFilter { get; set; }
        public PersonalityFilter PersonalityFilter { get; set; }
        public String PersonFilter { get; set; }
        public GenderFilter GenderFilter { get; set; }
        public String PartijFilter { get; set; }
        public String ThemeFilter { get; set; }
        public double SentimentStart { get; set; }
        public double SentimentEnd { get; set; }

        //VALUES
        [NotMapped]
        public double SingleValue { get; set; }
        [NotMapped]
        public Dictionary<string, double> BarValues { get; set; }
        [NotMapped]
        public Dictionary<string, List<double>> LineValues { get; set; }
        [NotMapped]
        public double TrendValue { get; set; } //-100 to 100
        [NotMapped]
        public double TrendArrowValue { get; set; }

        //CONSTRUCTORS
        public Graph(Account account)
        {
            Account = account;
        }
        public Graph()
        {

        }

    }
    public enum XType
    {
        interval,
        themes,
        time
    }
    public enum YType
    {
        males,
        females,
        malesProcent,
        femalesProcent,
        sentimentProcent
    }
    public enum GraphType
    {
        Single,
        SingleTrend,
        Barchart,
        Linechart
    }
    public enum CalcType
    {
        Sum,
        AVG
    }
    public enum AgeFilter
    {
        Both,
        plus25,
        min25
    }
    public enum PersonalityFilter
    {
        Both,
        E,
        I
    }
    public enum GenderFilter
    {
        Both,
        Male,
        Female
    }
    public enum PeriodSort
    {
        Fixed,
        Flex
    }
    public enum CompareSort
    {
        Politicians,Age,Gender
    }
}
