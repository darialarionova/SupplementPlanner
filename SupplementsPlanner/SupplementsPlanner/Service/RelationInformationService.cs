using System.Linq;
using SupplementsPlanner.Repository;
using System.Collections;

namespace SupplementsPlanner.Service
{
    public class RelationInformationService
    {
        public void SetSupplementsRelationInformation()
        {
            var fileService = new FileService();
            var supplementsRelations = fileService.GetRelationInformation();
            var relationInformationRepository = new RelationInformationRepository();

            foreach (var supplementsRelation in supplementsRelations)
            {
                relationInformationRepository.SetSupplementsRelation(supplementsRelation);
            }
        }
    }
}
