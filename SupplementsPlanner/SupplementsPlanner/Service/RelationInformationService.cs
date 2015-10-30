using System.Collections.Generic;
using System.Linq;
using SupplementsPlanner.Repository;

namespace SupplementsPlanner.Service
{
    public class RelationInformationService
    {
        private static Dictionary<string, string[]> CompatibilityInformation()
        {
            var compabilityInformation = new Dictionary<string, string[]>();

            compabilityInformation.Add("A", new[] { "C", "E", "B7" });
            compabilityInformation.Add("B1", new[] { "B5" });
            compabilityInformation.Add("B2", new[] { "B3", "B5", "B6", "B7", "B9", "K" });
            compabilityInformation.Add("B3", new[] { "B6", "B7" });
            compabilityInformation.Add("B4", new[] { "B5", "B8", "B9", "B12", "E" });
            compabilityInformation.Add("B5", new[] { "B9", "B10", "B12", "C" });
            compabilityInformation.Add("B6", new[] { "B7" });
            compabilityInformation.Add("B8", new[] { "E" });
            compabilityInformation.Add("B9", new[] { "B10", "B12", "C" });
            compabilityInformation.Add("B11", new[] { "B10", "B12", "C" });

            return compabilityInformation;
        }
        //todo: simplify?
        public void SetSupplementsRelationInformation()
        {
            var supplementService = new SupplementService();
            var supplements = supplementService.GetSupplements().ToList();

            var compatibilityInformationRepository = new RelationInformationRepository();

            var compatibilityInformation = CompatibilityInformation();

            foreach (var supplement in supplements)
            {
                var compatibleSupplements = compatibilityInformation[supplement.GetFullNotation()];
                if (compatibleSupplements != null)
                {
                    compatibleSupplements.ToList().ForEach(secondSupplementName =>
                    {
                        var secondSupplement = supplements.FirstOrDefault(s => s.GetFullNotation() == secondSupplementName);
                        compatibilityInformationRepository.SetSupplementsRelation(supplement, secondSupplement, Consts.RelationType.Compatible);
                    });
                }
                    
            }
        }
    }
}
