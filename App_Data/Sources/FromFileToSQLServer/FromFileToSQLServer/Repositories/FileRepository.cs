using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FromFileToSQLServer.Entities;

namespace FromFileToSQLServer.Repositories
{
    public class FileRepository
    {
        public IEnumerable<SupplementsRelation> GetSupplementsByRelationType(XElement supplement, string relationType)
        {
            return supplement.Elements(relationType).Select(s => new SupplementsRelation
                {
                    FirstSupplementNotation = supplement.Attribute(Consts.XmlTags.Notation).Value,
                    SecondSupplementNotation = s.Value,
                    SecondSupplementType = s.Attribute(Consts.XmlTags.Type).Value,
                    RelationType = relationType

                }).ToList();
        }

        public IEnumerable<SupplementsRelation> GetRelationInformation()
        {
            var supplementsRelationsXml = XDocument.Load(Consts.Settings.Path.SupplementsRelations);
            var supplementsRelations = new List<SupplementsRelation>();
            if (supplementsRelationsXml.Root == null)
            {
                return supplementsRelations;
            }
            var supplements = supplementsRelationsXml.Root.Elements(Consts.XmlTags.Supplement).ToArray();
            foreach (var supplement in supplements)
            {
                supplementsRelations.AddRange(GetSupplementsByRelationType(supplement, Consts.RelationTypes.Compatible));
                supplementsRelations.AddRange(GetSupplementsByRelationType(supplement, Consts.RelationTypes.Incompatible));
            }
            return supplementsRelations;
        }

        public IEnumerable<Supplement> GetSupplements()
        {
            var supplementsXml = XDocument.Load(Consts.Settings.Path.Supplements);

            if (supplementsXml.Root == null)
            {
                return null;
            }
            return supplementsXml.Root.Elements(Consts.XmlTags.Supplement).Select(s => new Supplement
            {
                Notation = s.Attribute(Consts.XmlTags.Notation).Value,
                FullName = s.Element(Consts.XmlTags.FullName + Consts.Settings.CurrentLanguage).Value,
                Type = s.Attribute(Consts.XmlTags.Type).Value
            }).ToList();
        }
    }
}
