using System.Collections.Generic;
using SupplementsPlanner.Entities;
using SupplementsPlanner.Repository;

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