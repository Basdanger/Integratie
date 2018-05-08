using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Graph
{
    public class Graph
    {
        public int GraphId { get; set; }
        public Account Account { get; set; }
        public GraphType GraphType { get; set; }
        public CalcType CalcType { get; set; }

        //AXISTYPE
        public XType XAxisType { get; set; }
        public YType YAxisType { get; set; }

        //TIME
        public PeriodSort PeriodSort { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PeriodLength { get; set; }

        //INTERVAL
        public double StartInterval { get; set; }
        public double EndInterval { get; set; }
        public double IntervalSize { get; set; }

        //FILTERS
        public AgeFilter AgeFilter { get; set; }
        public PersonalityFilter PersonalityFilter { get; set; }
        public List<string> PersonFilter { get; set; }
        public GenderFilter GenderFilter { get; set; }

        //VALUES
        [NotMapped]
        public double SingleValue { get; set; }

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
        sentimentProcent,


    }
    public enum GraphType
    {
        Single,
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
}
