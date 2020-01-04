using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyHelper.Models
{
    public class Route
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Deposit { get; set; }
    }
}
