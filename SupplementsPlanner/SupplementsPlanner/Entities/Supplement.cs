namespace SupplementsPlanner.Entities
{
    public class Supplement
    {
        public int Id { get; set; }
        public string Notation { get; set; }
        public string NotationNumber { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; }
        public string Solvent { get; set; }

        public string GetFullNotation()
        {
            return Notation + NotationNumber;
        }
    }
}
