using System.Collections.Generic;
using FromFileToSQLServer.Entities;
using FromFileToSQLServer.Repositories;

namespace FromFileToSQLServer.Services
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
