using System.Collections.Generic;
using SupplementsPlanner.Entities;
using SupplementsPlanner.Repository;

namespace SupplementsPlanner.Service
{
    public class SupplementService
    {
        public void SetSupplements(IEnumerable<Supplement> supplements)
        {
            var supplementRepository = new SupplementRepository();
            foreach (var supplement in supplements)
            {
                supplementRepository.SetSupplement(supplement);
            }
        }

        public IEnumerable<Supplement> GetSupplements()
        {
            var supplementRepository = new SupplementRepository();
            return supplementRepository.GetSupplements();
        }
    }
}
