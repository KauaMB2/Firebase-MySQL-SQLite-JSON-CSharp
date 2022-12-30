using System;
using System.Data;
using System.Data.SQLite;

namespace CRUD_SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to the database
            SQLiteConnection connection = new SQLiteConnection("Data Source=DB/MyDatabase.db;Version=3;");
            connection.Open();

            // Create a table
            string createTableSql = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, email TEXT)";
            SQLiteCommand createTableCommand = new SQLiteCommand(createTableSql, connection);
            createTableCommand.ExecuteNonQuery();//Execute the query

            // Insert a data
            string insertSql = "INSERT INTO users (name, email) VALUES (@name, @email)";
            SQLiteCommand insertCommand = new SQLiteCommand(insertSql, connection);
            insertCommand.Parameters.AddWithValue("@name", "John");
            insertCommand.Parameters.AddWithValue("@email", "john@example.com");
            insertCommand.ExecuteNonQuery();//Execute the query

            // Read data
            string selectSql = "SELECT * FROM users";
            SQLiteCommand selectCommand = new SQLiteCommand(selectSql, connection);
            SQLiteDataReader reader = selectCommand.ExecuteReader();//Execute the query
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string email = reader.GetString(2);
                Console.WriteLine($"{id}: {name} ({email})");
            }
            reader.Close();

            // Update a data
            string updateSql = "UPDATE users SET name = @name WHERE id = @id";
            SQLiteCommand updateCommand=new SQLiteCommand(updateSql, connection);
            updateCommand.Parameters.AddWithValue("@name", "Jane");
            updateCommand.Parameters.AddWithValue("@id", 1);
            updateCommand.ExecuteNonQuery();//Execute the query

            //Select the rows amount in table
            string amountRowsSql="SELECT MAX(id) FROM users;";
            SQLiteCommand amountRowsCommand=new SQLiteCommand(amountRowsSql,connection);
            int idMax=0;
            try{
                reader=amountRowsCommand.ExecuteReader();
                while (reader.Read()){
                    idMax = reader.GetInt32(0);
                }
            }catch{
                idMax=0;
            }
            Console.WriteLine("Maior Id da tabela: {0}",idMax);
            // Delete a data
            string deleteSql = "DELETE FROM users WHERE id = @id";
            SQLiteCommand deleteCommand = new SQLiteCommand(deleteSql, connection);
            deleteCommand.Parameters.AddWithValue("@id", 5);
            deleteCommand.ExecuteNonQuery();

            // Close the connection
            connection.Close();
        }
    }
}