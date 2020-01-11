﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyHelper.Models
{
    public class DaysInRoute
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DayBySequence { get; set; }
        [NotMapped]
        public Route Route { get; set; }
        public long RouteId { get; set; } // value is not mapped because Route is already represented as RouteId
        public string Country { get; set; }
        public string Description { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool? IsActive { get; set; }
    }
}
