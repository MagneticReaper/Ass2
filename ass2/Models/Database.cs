using System.Data.SQLite;

namespace Models
{
    public class Database
    {
        public static void CreateTable() // one time use, on first run or if database gets deleted
        { // Create Table
            try
            {// get connection
                SQLiteConnection sqlite_conn = new("Data Source=database.db; Version = 3; New = True; Compress = True; ");
                sqlite_conn.Open();
                // create command
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                // set the command
                sqlite_cmd.CommandText = "CREATE TABLE Product (id INTEGER unique, name varchar(255), amount INTEGER, price REAL)";
                // execute
                sqlite_cmd.ExecuteNonQuery();
                // TODO: seed table
                sqlite_conn.Close();
            }
            // fail silently when table already exists
            catch (Exception) { }
        }
    }
}
