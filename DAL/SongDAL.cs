using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class SongDAL
    {
        private SqlConnection _connection;

        public SongDAL()
        {
            _connection = DB.ConnectToDB();
        }

        public List<Preference> GetUsers()
        {
            List<Preference> users = new List<Preference>();
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand("spGetUsers", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Preference user = new Preference();
                    user.UserID = reader.GetString(0);
                    user.Performer = reader.GetInt32(1);
                    user.Title = reader.GetInt32(2);
                    users.Add(user);
                }
            }
            return users;
        }

        public Preference GetPreference(string userID)
        {
            Preference preference = new Preference();
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand("spGetPreference", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userID);
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    preference.UserID = reader.GetString(0);
                    preference.Performer = reader.IsDBNull(1) ? -1 : reader.GetInt32(1);
                    preference.Title = reader.IsDBNull(2)? -1 : reader.GetInt32(2);
                }
            }
            return preference;
        }

        public bool SavePreference(string userID, int performer, int title)
        {
            int rowsAffected;
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand("spSavePreference", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@Performer", performer);
                cmd.Parameters.AddWithValue("@Title", title);
                _connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }

        public List<Artist> GetAllArtists()
        {
            List<Artist> allArtists = new List<Artist>();
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand("spGetAllArtists", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artist artist = new Artist();
                    artist.ArtistID = reader.GetInt32(0);
                    artist.Performer = reader.GetString(1);
                    allArtists.Add(artist);
                }
            }
            return allArtists;
        }

        public List<SongCollection> GetAllSongs()
        {
            List<SongCollection> allSongs = new List<SongCollection>();
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand("spGetAllSongs", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SongCollection song = new SongCollection();
                    song.SongID = reader.GetInt32(0);
                    song.Title = reader.GetString(1);
                    song.ArtistID = reader.GetInt32(2);
                    song.Price = reader.GetInt32(3);
                    allSongs.Add(song);
                }
            }
            return allSongs;
        }

        public SongCollection GetSong(int songID)
        {
            SongCollection song = new SongCollection();
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand("spGetSong", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SongID", songID);
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    song.SongID = songID;
                    song.Title = reader.GetString(0);
                    song.ArtistID = reader.GetInt32(1);
                    song.Price = reader.GetInt32(2);
                }
            }
            return song;
        }

        public int AddSong(int artistID, string title, int price)
        {
            int rowsAffected;
            int id;
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand("spAddSong", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ArtistID", artistID);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.Add("@NewID", SqlDbType.Int, 0, "ID");
                cmd.Parameters["@NewID"].Direction = ParameterDirection.Output;
                _connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                id = (int)cmd.Parameters["@NewID"].Value;
            }
            if (rowsAffected == 1)
            {
                return id;
            }
            return 0;
        }

        public bool UpdateSong(int songID, string title, int artistID, int price)
        {
            int rowsAffected;
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand("spUpdateSong", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SongID", songID);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@ArtistID", artistID);
                cmd.Parameters.AddWithValue("@Price", price);
                _connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }

        public List<SongCollection> SearchByPerformer(int artistID, string zoekterm = "")
        {
            List<SongCollection> songs = new List<SongCollection>();
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand("spSearchByPerformer", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ArtistID", artistID);
                cmd.Parameters.AddWithValue("@Zoekterm", zoekterm);
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SongCollection song = new SongCollection();
                    song.SongID = reader.GetInt32(0);
                    song.Title = reader.GetString(1);
                    song.ArtistID = reader.GetInt32(2);
                    song.Price = reader.GetInt32(3);
                    songs.Add(song);
                }
            }
            return songs;
        }

        public bool DeleteSong(int songID)
        {
            int rowsAffected;
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand("spDeleteSong", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SongID", songID);
                _connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }

        public DataTable Overview()
        {
            DataTable overview = new DataTable();
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand("spOverview", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(overview);
            }
            return overview;
        }
    }
}
