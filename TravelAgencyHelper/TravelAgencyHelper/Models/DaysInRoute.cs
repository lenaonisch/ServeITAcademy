using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyHelper.Models
{
    public class DaysInRoute
    {
        public int DayBySequence { get; set; }
        public Route Route { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
    }
}
