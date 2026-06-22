using System.Data;
using System.Data.SqlClient;

namespace DatabaseCrud
{
    internal class StudentiDAL
    {
        // accesso al database
        private SqlConnectionStringBuilder connectionString;

        public StudentiDAL()
        {
            connectionString = new SqlConnectionStringBuilder();
            connectionString.DataSource = @"localhost\sqlexpress";
            connectionString.UserID = @"swd";
            connectionString.Password = @"Its-2026";
            connectionString.InitialCatalog = "Anagrafica";
        }

        // operazioni CRUD
        public List<Studente> Elenco()
        {
            var elencoStudenti = new List<Studente>();
            // connessione db
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString.ConnectionString;
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = @"SELECT * FROM Studente";
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            elencoStudenti.Add(
                                new Studente
                                {
                                    Matricola = dataReader.GetInt16("Matricola"),
                                    Nome = dataReader.GetString("Nome"),
                                    Cognome = dataReader.GetString("Cognome"),
                                    Email = dataReader.GetString("email"),
                                    Classe = dataReader.GetString("classe")
                                });
                        }
                    }
                }
            }
            return elencoStudenti;
        }
    }
}
