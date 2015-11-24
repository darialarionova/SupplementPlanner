using System.Collections.Generic;
using FromFileToSQLServer.Entities;
using FromFileToSQLServer.Repositories;

namespace FromFileToSQLServer.Services
{
    public class RelationInformationService
    {
        public void SetSupplementsRelationInformation(List<SupplementsRelation> supplementsRelations)
        {
            var relationInformationRepository = new RelationInformationRepository();
            supplementsRelations.ForEach(supplementsRelation => relationInformationRepository.SetSupplementsRelation(supplementsRelation));
        }
    }
}
