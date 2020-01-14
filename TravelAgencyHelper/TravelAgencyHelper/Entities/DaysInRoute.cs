using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyHelper.Models
{
    public class DaysInRoute : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int DayBySequence { get; set; }
        [NotMapped]
        public Route Route { get; set; } // value is not mapped because Route is already represented as RouteId
        public long RouteId { get; set; } 
        public string Country { get; set; }
        public string Description { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool? IsActive { get; set; }
    }
}
