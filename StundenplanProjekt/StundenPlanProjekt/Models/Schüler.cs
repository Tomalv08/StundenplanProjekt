namespace StundenPlanProjekt.Models
{
    public class Schüler
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Ausbildungstyp { get; set; }
        public Schüler()
        {
            ID = Guid.NewGuid().ToString();
        }

    }

}
