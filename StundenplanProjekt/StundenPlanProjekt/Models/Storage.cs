using Blazored.LocalStorage;

namespace StundenPlanProjekt.Models
{

    public class Data
    {
        public Dictionary<string, Schüler> SchülerList { get; set; } = new Dictionary<string, Schüler>();
        public Dictionary<string, Lehrer> LehrerList { get; set; } = new Dictionary<string, Lehrer>();
        public Dictionary<string, Raum> RaumList { get; set; } = new Dictionary<string, Raum>();
        public Dictionary<string, Ausbildungstyp> AusbildungstypList { get; set; } = new Dictionary<string, Ausbildungstyp>();
        public Dictionary<string, Stundenplan> StundenplanList { get; set; } = new Dictionary<string, Stundenplan>();
    }

    public class Storage
    {
        private readonly ISyncLocalStorageService SyncLocalStorageService;
        private Data Data = new Data();

        public Storage(ISyncLocalStorageService syncLocalStorageService)
        {
            SyncLocalStorageService = syncLocalStorageService;
            LoadData();
        }
        public void SetRaum(Raum r)
        {
            Data.RaumList[r.ID] = r;
            SaveData();
        }
        public void SetSchüler(Schüler s)
        {
            Data.SchülerList[s.ID] = s;
            SaveData();
        }
        public void setStundenplan(Stundenplan stundenplan)
        {
            Data.StundenplanList[stundenplan.TableName] = stundenplan;
            SaveData();
        }
        public void SetLehrer(Lehrer l)
        {
            Data.LehrerList[l.ID] = l;
            SaveData();
        }
        public void SetAusbildungstyp(Ausbildungstyp a)
        {
            Data.AusbildungstypList[a.Name] = a;
            SaveData();
        }
        public Ausbildungstyp GetAusbildungstyp(string name)
        {
            return Data.AusbildungstypList[name];
        }
        public List<Raum> ListRaum()
        {
            return Data.RaumList.OrderBy(kvp => kvp.Value.Name).Select(kvp => kvp.Value).ToList();
        }
        public List<Lehrer> ListLehrer()
        {
            return Data.LehrerList.OrderBy(kvp => kvp.Value.Name).Select(kvp => kvp.Value).ToList();
        }
        public List<Lehrer> GetAvailableLehrer(string dayOfWeek)
        {
            // Filtere Lehrer basierend auf Verfügbarkeit für den ausgewählten Wochentag
            var availableLehrer = Data.LehrerList
                .Where(kvp => !kvp.Value.NichtVerfügbarTage.Contains(GetDayOfWeekFromString(dayOfWeek)))
                .Select(kvp => kvp.Value)
                .OrderBy(lehrer => lehrer.Name)
                .ToList();

            return availableLehrer;
        }

        // Hilfsmethode zum Konvertieren von Wochentagszeichenfolgen in ein Enum-Objekt
        private DayOfWeek GetDayOfWeekFromString(string dayOfWeek)
        {
            return Enum.Parse<DayOfWeek>(dayOfWeek);
        }

        public List<Schüler> ListSchüler()
        {
            return Data.SchülerList.OrderBy(kvp => kvp.Value.Name).Select(kvp => kvp.Value).ToList();
        }
        public List<Ausbildungstyp> ListAusbildungstyp()
        {
            return Data.AusbildungstypList.OrderBy(kvp => kvp.Value.ModuleText).Select(kvp => kvp.Value).ToList();
        }
        public void DeleteRaum(string id)
        {
            Data.RaumList.Remove(id);
            SaveData();
        }
        public void DeleteSchüler(string id)
        {
            Data.SchülerList.Remove(id);
            SaveData();
        }
        public void DeleteLehrer(string id)
        {
            Data.LehrerList.Remove(id);
            SaveData();
        }
        public void DeleteAusbildungstyp(string id)
        {
            Data.AusbildungstypList.Remove(id);
            SaveData();
        }
        private void LoadData()
        {
            try
            {
                Data stored = SyncLocalStorageService.GetItem<Data>("data");
                if (stored != null)
                {
                    Data = stored;
                }
            }
            catch (Exception) { }
        }

        private void SaveData()
        {
            SyncLocalStorageService.SetItem("data", Data);
        }
    }
}
