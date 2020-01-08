using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyHelper.Models
{
    public class Route
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Deposit { get; set; }
        public string Category { get; set; }
        //public List<DaysInRoute> Days { get; set; }

        //public Route()
        //{
        //    Days = new List<DaysInRoute>();
        //}
    }
}
