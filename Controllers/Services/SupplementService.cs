using System.Collections.Generic;
using System.Drawing;
using SupplementsPlanner;
using SupplementsPlannerWeb.Entities;
using SupplementsPlannerWeb.Models.Repositories;

namespace SupplementsPlannerWeb.Controllers.Services
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
        public IEnumerable<Supplement> GetSupplementsByType(string type)
        {
            var supplementRepository = new SupplementRepository();
            return supplementRepository.GetSupplementsByType(type);
        }
        public Supplement GetSupplementById(int id)
        {
            var supplementRepository = new SupplementRepository();
            return supplementRepository.GetSupplementById(id);
        }
    }
}
