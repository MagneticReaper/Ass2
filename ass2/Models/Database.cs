using System.Data.SQLite;

namespace ass2.Models
{
    public class Database
    {
        public static void CreateTable()
        { // Create Table
            try
            {// get connection
                SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
                sqlite_conn.Open();
                SQLiteCommand sqlite_cmd;
                // create command
                sqlite_cmd = sqlite_conn.CreateCommand();
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
