namespace StundenPlanProjekt.Models
{
    public class Ausbildungstyp
    {
        public string Name { get; set; }
        public string ModuleText { get; set; }

        public List<string> Modules()
        {
            return ModuleText.Split(",").ToList();
        }
    }
}
