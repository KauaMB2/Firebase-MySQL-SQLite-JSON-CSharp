using MySql.Data.MySqlClient;
using System;

namespace MyApp{
    class Program{
    	private static MySqlConnection connection;
    	private static MySqlDataReader reader;
    	private static MySqlCommand command;
        static void Main(string[] args){
            // Connect to the database
            string connectionString = "server=localhost;database=test;user id=root;password=12345";
            connection = new MySqlConnection(connectionString);
            connection.Open();

            // Insert a new row into the table
            command = new MySqlCommand("INSERT INTO test_table (col2) VALUES ('hello')", connection);
            command.ExecuteNonQuery();
            connection.Close();

            // Select rows from the table
            connection.Open();
            command=new MySqlCommand("SELECT * FROM test_table", connection);
            reader=command.ExecuteReader();
            while (reader.Read()){
                int col1=reader.GetInt32(0);
                string col2=reader.GetString(1);
                Console.WriteLine("{0} - {1}",col1,col2);
            }
            connection.Close();

            // Update a row in the table
            connection.Open();
            command=new MySqlCommand("UPDATE test_table SET col2 = 'world' WHERE col1 = 1", connection);
            command.ExecuteNonQuery();
            connection.Close();

            // Select rows from the table
            connection.Open();
            command=new MySqlCommand("SELECT * FROM test_table", connection);
            reader=command.ExecuteReader();
            while (reader.Read()){
                int col1 = reader.GetInt32(0);
                string col2 = reader.GetString(1);
                Console.WriteLine("{0} - {1}",col1,col2);
            }
            connection.Close();

            //Select rows amount from the table
            connection.Open();
            int id=0;
            try{
                command=new MySqlCommand("SELECT MAX(col1) FROM test_table", connection);
                reader=command.ExecuteReader();
                while (reader.Read()){
                    id=reader.GetInt32(0);
                }
            }
            catch{
                id=0;
            }
            Console.WriteLine("Maior Id encontrado: {0}",id);
            connection.Close();
            
            // Delete a row from the table
            connection.Open();
            command = new MySqlCommand("DELETE FROM test_table WHERE col1 = 5", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
