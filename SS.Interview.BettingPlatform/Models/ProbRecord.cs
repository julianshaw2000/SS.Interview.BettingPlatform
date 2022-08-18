using SS.Interview.BettingPlatform.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Interview.BettingPlatform.Models
{
    public class ProbRecord
    {
        public SportType SportType { get; set; }
        public double Prob { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
