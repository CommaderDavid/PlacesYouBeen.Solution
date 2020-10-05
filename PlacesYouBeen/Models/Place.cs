using System.Collections.Generic;

namespace PlacesYouBeen.Models
{
    public class Place
    {
        public string CityName { get; set; }
        public string Duration { get; set; }
        public string Group { get; set; }
        public string JournalEntry { get; set; }
        public int Id { get; }
        private static List<Place> _instances = new List<Place> ();

        public Place(string cityName, string duration, string group, string journalEntry)
        {
            CityName = cityName;
            Duration = duration;
            Group = group;
            JournalEntry = journalEntry;
            _instances.Add(this);
            Id = _instances.Count;
        }

        public static List<Place> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static Place Find(int searchId)
        {
            return _instances[searchId - 1];
        }
    }
}