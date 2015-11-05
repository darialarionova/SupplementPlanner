using SupplementsPlanner.Entities;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace SupplementsPlanner.Repository
{
    public class FileRepository
    {
        public IEnumerable<SupplementsRelation> GetSupplementsByRelationType(XElement supplement, string relationType)
        {
            return supplement.Elements(relationType).Select(s => new SupplementsRelation
                {
                    First = supplement.Attribute(Consts.XmlTags.Notation).Value,
                    Second = s.Value,
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
                supplementsRelations.AddRange(GetSupplementsByRelationType(supplement, Consts.RelationTypes.Uncompatible));
            }
            //supplementsRelations.Rows.Add("A", new[] { "C", "E", "B7" }, Consts.RelationTypes.Compatible);
            //supplementsRelations.Rows.Add("B1", new[] { "B5" }, Consts.RelationTypes.Compatible);
            //supplementsRelations.Rows.Add("B2", new[] { "B3", "B5", "B6", "B7", "B9", "K" }, Consts.RelationTypes.Compatible);
            //supplementsRelations.Rows.Add("B3", new[] { "B6", "B7" }, Consts.RelationTypes.Compatible);
            //supplementsRelations.Rows.Add("B4", new[] { "B5", "B8", "B9", "B12", "E" }, Consts.RelationTypes.Compatible);
            //supplementsRelations.Rows.Add("B5", new[] { "B9", "B10", "B12", "C" }, Consts.RelationTypes.Compatible);
            //supplementsRelations.Rows.Add("B6", new[] { "B7" }, Consts.RelationTypes.Compatible);
            //supplementsRelations.Rows.Add("B8", new[] { "E" }, Consts.RelationTypes.Compatible);
            //supplementsRelations.Rows.Add("B9", new[] { "B10", "B12", "C" }, Consts.RelationTypes.Compatible);
            //supplementsRelations.Rows.Add("B11", new[] { "B10", "B12", "C" }, Consts.RelationTypes.Compatible);
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
                Solvent = s.Element(Consts.XmlTags.Solvent).Value,
                Type = s.Attribute(Consts.XmlTags.Type).Value
            }).ToList();
        }
    }
}
