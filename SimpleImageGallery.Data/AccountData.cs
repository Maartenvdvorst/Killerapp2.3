using ImageGallery.Interfaces;
using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ImageGallery.Data
{
    public class AccountData : IAccountLogicDal
    {
        private readonly SqlConnection _connection = new SqlConnection("Data Source = (localdb)\\mssqllocaldb;Database=SimpleImageGallery;Trusted_Connection=True;MultipleActiveResultSets=true");
        public async Task CreateNewAccount(string gebruikersnaam, string wachtwoord, string email)
        {
            using (SqlCommand query = new SqlCommand("INSERT INTO Logingegevens(Gebruikersnaam, Wachtwoord, Email, Created, Rol) VALUES (@Gebruikernsaam, @Wachtwoord, @Email, @Created, @Rol)", _connection))
            {
                _connection.Open();
                query.Parameters.AddWithValue("@Gebruikernsaam", gebruikersnaam);
                query.Parameters.AddWithValue("@Wachtwoord", wachtwoord);
                query.Parameters.AddWithValue("@Email", email);
                query.Parameters.AddWithValue("@Created", DateTime.Now);
                query.Parameters.AddWithValue("@Rol", "User");
                query.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public IEnumerable<Accountlayout> GetAllUsers()
        {
            List<Accountlayout> allAccounts = new List<Accountlayout>();
            using (SqlCommand query = new SqlCommand("SELECT * FROM Logingegevens", _connection))
            {
                _connection.Open();
                try
                {
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var account = new Accountlayout
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Gebruikersnaam = reader["Gebruikersnaam"].ToString(),
                                Wachtwoord = reader["Wachtwoord"].ToString(),
                                Email = reader["Email"].ToString(),
                                Created = Convert.ToDateTime(reader["Created"]),
                                Rol = reader["Rol"].ToString()
                            };
                            allAccounts.Add(account);
                        }
                        reader.Close();
                    }
                }
                catch
                {
                    return null;
                }

                _connection.Close();
                return allAccounts;
            }
        }

        public Accountlayout GetUserByName(string username)
        {
            IEnumerable<Accountlayout> allAccounts = GetAllUsers();
            foreach (Accountlayout account in allAccounts)
            {
                if (account.Gebruikersnaam == username)
                {
                    return account;
                }
            }
            return null;
        }

        public string GetPasswordByUsername(string username)
        {
            try
            {
                return GetUserByName(username).Wachtwoord;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public async Task ChangeUser(string gebruikersnaam, string wachtwoord, string OldUserName)
        {
            using (SqlCommand query = new SqlCommand("UPDATE Logingegevens SET Gebruikersnaam = @Gebruikersnaam, Wachtwoord = @Wachtwoord WHERE Gebruikersnaam = @Oldgebruikersnaam", _connection))
            {
                _connection.Open();
                query.Parameters.AddWithValue("@Gebruikersnaam", gebruikersnaam);
                query.Parameters.AddWithValue("@Wachtwoord", wachtwoord);
                query.Parameters.AddWithValue("@Oldgebruikersnaam", OldUserName);
                query.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public string GetRol(string username)
        {
            using (SqlCommand query = new SqlCommand("SELECT Rol FROM Logingegevens WHERE Gebruikersnaam = @username", _connection))
            {
                string rol = null;
                _connection.Open();
                query.Parameters.AddWithValue("@username", username);
                try
                {
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rol = reader["Rol"].ToString();
                        }
                        reader.Close();
                    }
                }
                catch
                {
                    return null;
                }

                _connection.Close();
                return rol;
            }
        }
    }
}
