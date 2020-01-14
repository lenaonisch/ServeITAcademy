using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using TravelAgencyHelper.Data;

namespace TravelAgencyHelper.Helpers
{
    public class EFTrueValueGenerator : ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;

        private readonly TravelAgencyContext _context;

        public EFTrueValueGenerator(TravelAgencyContext context)
        {
            _context = context;
        }

        protected override object NextValue(EntityEntry entry)
        {
            return true;
        }
    }
}