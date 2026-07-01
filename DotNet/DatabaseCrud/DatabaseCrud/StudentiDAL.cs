using Microsoft.Data.SqlClient;
using System.Data;

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
            connectionString.TrustServerCertificate = true;
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

        public Studente Dettaglio(int matricola)
        {
            Studente? s = null;
            // connessione db
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString.ConnectionString;
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = $"SELECT * FROM Studente WHERE matricola={matricola}";
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            s = new Studente
                            {
                                Matricola = dataReader.GetInt16("Matricola"),
                                Nome = dataReader.GetString("Nome"),
                                Cognome = dataReader.GetString("Cognome"),
                                Email = dataReader.GetString("email"),
                                Classe = dataReader.GetString("classe")
                            };
                        }
                    }
                }
            }
            return s ?? throw new Exception($"Studente con matricola {matricola} non trovato");
        }

        public void Nuovo(Studente s)
        {
            // connessione db
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString.ConnectionString;
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = $"INSERT INTO Studente(Matricola, Nome, Cognome, Email, Classe)" +
                        $"VALUES(" +
                        $"@matricola," +
                        $"@nome," +
                        $"@cognome," +
                        $"@email," +
                        $"@classe" +
                        $")";

                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.Parameters.Add("@matricola", SqlDbType.Int).Value = s.Matricola;
                    command.Parameters.Add("@nome", SqlDbType.VarChar).Value = s.Nome;
                    command.Parameters.Add("@cognome", SqlDbType.VarChar).Value = s.Cognome;
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = s.Email;
                    command.Parameters.Add("@classe", SqlDbType.VarChar).Value = s.Classe;


                    int rows = command.ExecuteNonQuery();

                    if(rows != 1)
                    {
                        throw new Exception("ERRORE INSERIMENTO FALLITO");
                    }

                }
            }
        }

        public void Modifica(Studente s)
        {
            // connessione db
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString.ConnectionString;
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = $"UPDATE Studente SET nome=@nome, cognome=@cognome, email=@email, classe=@classe WHERE matricola=@matricola";

                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.Parameters.Add("@matricola", SqlDbType.Int).Value = s.Matricola;
                    command.Parameters.Add("@nome", SqlDbType.VarChar).Value = s.Nome;
                    command.Parameters.Add("@cognome", SqlDbType.VarChar).Value = s.Cognome;
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = s.Email;
                    command.Parameters.Add("@classe", SqlDbType.VarChar).Value = s.Classe;


                    int rows = command.ExecuteNonQuery();

                    if (rows != 1)
                    {
                        throw new Exception("ERRORE AGGIORNAMENTO FALLITO");
                    }

                }
            }
        }

        public void Elimina(Studente s)
        {
            // connessione db
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString.ConnectionString;
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = $"DELETE FROM Studente WHERE matricola=@matricola";

                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.Parameters.Add("@matricola", SqlDbType.Int).Value = s.Matricola;

                    int rows = command.ExecuteNonQuery();

                    if (rows != 1)
                    {
                        throw new Exception("ERRORE ELIMINAZIONE FALLITO");
                    }

                }
            }
        }

    }
}
