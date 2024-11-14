namespace StundenPlanProjekt.Models
{
    public class Stundenplan
    {
        public string TableName { get; set; }
        public List<TableEntry> TableEntries { get; set; } = new List<TableEntry>();
    }
}
