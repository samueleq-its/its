using System.Data;
using System.Data.SqlClient;

namespace ConnessioneDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connessione al dbms SQL Server!");

            // stringa di connessione
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
            connectionString.DataSource = @"localhost\sqlexpress";
            connectionString.UserID = @"sa";
            connectionString.Password = @"Its-2026";
            connectionString.InitialCatalog = "Istat";

            // accesso al database
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString.ConnectionString;
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine("Connessione al database avvenuta");

            // accesso ai dati
            SqlCommand command = new SqlCommand();
            string sql = "select Id, Denominazione from Regione";
            command.CommandText = sql;
            command.CommandType = CommandType.Text; // la query è testuale ed embedded
            try
            {
                command.Connection = connection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("Accesso ai dati avvenuto");

            Console.WriteLine("Id\t|\tRegione");
            try
            {
                while (reader.Read())
                {
                    Console.Write($"{reader.GetInt32("Id")}");
                    Console.Write($"\t|\t{reader.GetString("Denominazione")}\n");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            reader.Close();
            command.Dispose();
            connection.Close();
        }
    }
}
