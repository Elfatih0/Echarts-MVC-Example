using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTest.Models
{
    public class ChartModel
    {
        public ChartModel()
        {
            Legend = new List<string>();
            Series = new List<SeriesRec>();
        }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public List<string> Legend { get; set; }
        public List<SeriesRec> Series { get; set; }
    }
    public class SeriesRec
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
