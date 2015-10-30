using System.Collections.Generic;
using SupplementsPlanner.Entities;
using SupplementsPlanner.Repository;

namespace SupplementsPlanner.Service
{
    public class SupplementService
    {
        public IEnumerable<Supplement> GetSupplements()
        {
            var supplementRepository = new SupplementRepository();
            return supplementRepository.GetSupplements();
        }
    }
}
