using System.Collections.Generic;
using SupplementsPlannerWeb.Entities;
using SupplementsPlannerWeb.Models.Repositories;

namespace SupplementsPlanner.Service
{
    public class FileService
    {
        public IEnumerable<Supplement> GetSupplements()
        {
            var predefinedInformationRepository = new FileRepository();
            return predefinedInformationRepository.GetSupplements();
        }

        public IEnumerable<SupplementsRelation> GetRelationInformation()
        {
            var predefinedInformationRepository = new FileRepository();
            return predefinedInformationRepository.GetRelationInformation();
        }
    }
}