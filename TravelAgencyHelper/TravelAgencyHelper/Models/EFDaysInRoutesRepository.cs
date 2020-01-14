using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgencyHelper.Data;

namespace TravelAgencyHelper.Models
{
    public class EFDaysInRoutesRepository : EFGenericRepository<DaysInRoute>
    {

        public EFDaysInRoutesRepository(TravelAgencyContext context) : base(context)
        {
            _context = context;
        }
    }
}
