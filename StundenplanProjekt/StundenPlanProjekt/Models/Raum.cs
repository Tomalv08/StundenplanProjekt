namespace StundenPlanProjekt.Models
{
    public class Raum
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Sitzplatzanzahl { get; set; }
        public string Ausstattung { get; set; }
        public Raum()
        {
            ID = Guid.NewGuid().ToString();
        }
    }


}
