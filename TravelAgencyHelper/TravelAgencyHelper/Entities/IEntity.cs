using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyHelper.Models
{
    public interface IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        long Id { get; set; }
        bool? IsActive { get; set; }
    }
}
