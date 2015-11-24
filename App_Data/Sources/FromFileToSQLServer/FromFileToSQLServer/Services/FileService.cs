using System.Collections.Generic;
using FromFileToSQLServer.Entities;
using FromFileToSQLServer.Repositories;

namespace FromFileToSQLServer.Services
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