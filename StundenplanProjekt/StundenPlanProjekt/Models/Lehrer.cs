namespace StundenPlanProjekt.Models
{
    public class Lehrer
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public List<DayOfWeek> NichtVerfügbarTage { get; set; }
        public string NichtVerfügbarTageText { get; set; }
        public Lehrer()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}
