using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SupplementsPlanner.Service;
using SupplementsPlannerWeb.Models.Repositories;
using SupplementsPlannerWeb.Entities;

namespace SupplementsPlannerWeb.Controllers.Services
{
    public class RelationInformationService
    {
        public void SetSupplementsRelations()
        {
            var fileService = new FileService();
            var supplementsRelations = fileService.GetRelationInformation().ToList();

            var relationInformationRepository = new RelationInformationRepository();
            supplementsRelations.ForEach(supplementsRelation => relationInformationRepository.SetSupplementsRelation(supplementsRelation));
        }
        public IEnumerable<object> GetSupplementRelations(int id, string type)
        {
            var relationInformationRepository = new RelationInformationRepository();
            return relationInformationRepository.GetSupplementRelations(id, type);
        }
    }
}
