namespace SupplementsPlanner
{
    public static class Consts
    {
        public struct Settings
        {
            public static readonly string CurrentLanguage = Languages.Russian;
        }

        public struct Languages
        {
            public static readonly string Russian = "Russian";
        }

        public struct SupplementCategory
        {
            public static readonly string Vitamin = "Vitamin";
            public static readonly string VitaminLikeSubstance = "Vitamin-Like Substance";
            public static readonly string Mineral = "Mineral";
        }

        public struct RelationType
        {
            public static readonly string Compatible = "Compatible";
            public static readonly string Uncompatible = "Uncompatible";
            public static readonly string Neutral = "Neutral";
        }
    }
}
