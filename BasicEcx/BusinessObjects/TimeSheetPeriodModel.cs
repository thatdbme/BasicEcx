using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicEcx.BusinessObjects
{
    /// <summary>
    /// Local version of business object used in application
    /// </summary>
    public class TimeSheetPeriodModel
    {
        public int TimeSheetPeriodId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TimeSheetFrequencyId { get; set; }

        public int TimeSheetCycleId { get; set; }

        public Dictionary<string, string> TimeSheetCycleList { get; set; }

        public Dictionary<string, string> TimeSheetFrequencyList { get; set; }


    }
}