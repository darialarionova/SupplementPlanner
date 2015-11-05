namespace SupplementsPlanner
{
    public static class Consts
    {
        public struct Settings
        {
            public static readonly string CurrentLanguage = Languages.Russian;

            public struct Path
            {
                public static readonly string SupplementsRelations = @"D:\mine\SupplementsPlanner\SupplementsPlanner\DefaultData\SupplementsRelationsInformation.xml";
                public static readonly string Supplements = @"D:\mine\SupplementsPlanner\SupplementsPlanner\DefaultData\Supplements.xml";
            }
        }

        public struct Languages
        {
            public static readonly string Russian = "Russian";
            public static readonly string English = "English";
        }

        public struct SupplementCategories
        {
            public static readonly string Vitamin = "Vitamin";
            public static readonly string VitaminLikeSubstance = "Vitamin-Like Substance";
            public static readonly string Mineral = "Mineral";
        }

        public struct RelationTypes
        {
            public static readonly string Compatible = "Compatible";
            public static readonly string Uncompatible = "Uncompatible";
        }

        public struct XmlTags
        {
            public static readonly string Supplement = "Supplement";
            public static readonly string Notation = "Notation";
            public static readonly string FullName = "FullName";
            public static readonly string Type = "Type";
            public static readonly string Solvent = "Solvent";
        }
    }
}
