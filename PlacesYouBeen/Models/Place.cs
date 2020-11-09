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

        public Place (string name, string duration, string group, string journal, int id)
        {
            CityName = name;
            Duration = duration;
            Group = group;
            JournalEntry = journal;
            Id = id;
        }

        public override bool Equals(System.Object otherPlace)
        {
            if (!(otherPlace is Place))
            {
                return false;
            }
            else
            {
                Place newPlace = (Place) otherPlace;
                bool idEquality = (this.Id == newPlace.Id);
                bool nameEquality = (this.CityName == newPlace.CityName);
                bool durationEquality = (this.Duration == newPlace.Duration);
                bool groupEquality = (this.Group == newPlace.Group);
                bool journalEquality = (this.JournalEntry == newPlace.JournalEntry);
                return (idEquality && nameEquality && durationEquality && groupEquality && journalEquality);
            }
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
                int placeId = rdr.GetInt32(0);
                string placeName = rdr.GetString(1);
                string placeDuration = rdr.GetString(1);
                string placeGroup = rdr.GetString(1);
                string placeJournal = rdr.GetString(1);
                Place newPlace = new Place(placeName, placeDuration, placeGroup, placeJournal, placeId);
                allPlaces.Add(newPlace);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allPlaces;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;

            // Begin new code

            cmd.CommandText = @"INSERT INTO places (name) VALUES (@PlaceName);";
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@PlaceName";
            param.Value = this.CityName;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            Id = (int) cmd.LastInsertedId;

            //Need more param?

            // End new code

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM places;";
            cmd.ExecuteNonQuery();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Place Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM places WHERE id = @ThisId;";

            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@ThisId";
            param.Value = id;
            cmd.Parameters.Add(param);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int placeId = 0;
            string placeName = "";
            string placeDuration = "";
            string placeGroup = "";
            string placeJournal = "";
            while (rdr.Read())
            {
                int placeId = rdr.GetInt32(0);
                string placeName = rdr.GetString(1);
                string placeDuration = rdr.GetString(1);
                string placeGroup = rdr.GetString(1);
                string placeJournal = rdr.GetString(1);
                //Why aren't they working?
            }
            Place foundPlace = new Place(placeName, placeDuration, placeGroup, placeJournal, placeId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundPlace;
        }
    }
}