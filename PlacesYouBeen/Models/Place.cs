using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace PlacesYouBeen.Models
{
    public class Place
    {
        public string CityName { get; set; }
        public string Duration { get; set; }
        public string Group { get; set; }
        public string JournalEntry { get; set; }
        public int Id { get; set; }

        public Place(string cityName, string duration, string group, string journalEntry)
        {
            CityName = cityName;
            Duration = duration;
            Group = group;
            JournalEntry = journalEntry;
        }

        public static List<Place> GetAll()
        {
            List<Place> allPlaces = new List<Place>();
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM places;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int itemId = rdr.GetInt32(0);
                string itemDescription = rdr.GetString(1);
                Item newItem = new Item(itemDescription, itemId);
                allItems.Add(newItem);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allPlaces;
            }

        public static void ClearAll()
        {
        }

        public static Place Find(int searchId)
        {
            return _instances[searchId - 1];
        }
    }
}