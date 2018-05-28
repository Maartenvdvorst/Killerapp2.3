using ImageGallery.Interfaces;
using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ImageGallery.Data
{
    public class AdminData : IAdminLogicDal
    {
        private readonly SqlConnection _connection = new SqlConnection("Data Source = (localdb)\\mssqllocaldb;Database=SimpleImageGallery;Trusted_Connection=True;MultipleActiveResultSets=true");
        public async Task DeletePost(int id)
        {
            using (SqlCommand query = new SqlCommand("DELETE FROM GalleryImages WHERE Id = @PostId", _connection))
            {
                _connection.Open();
                query.Parameters.AddWithValue("@PostId", id);
                query.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public async Task DeleteComment(int id)
        {
            using (SqlCommand query = new SqlCommand("DELETE FROM Comments WHERE CommentId = @CommentId", _connection))
            {
                _connection.Open();
                query.Parameters.AddWithValue("@CommentId", id);
                query.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public IEnumerable<Accountlayout> GetAllUsers(string username)
        {
            using (SqlCommand query = new SqlCommand("SELECT * FROM Logingegevens", _connection))
            {
                List<Accountlayout> alleUsers = new List<Accountlayout>();
                _connection.Open();
                try
                {
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string Username = null;
                            var account = new Accountlayout
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Gebruikersnaam = reader["Gebruikersnaam"].ToString(),
                                Wachtwoord = reader["Wachtwoord"].ToString(),
                                Email = reader["Email"].ToString(),
                                Created = Convert.ToDateTime(reader["Created"]),
                                Rol = reader["Rol"].ToString()
                            };
                            Username = reader["Gebruikersnaam"].ToString();
                            if (Username != username)
                            {
                                alleUsers.Add(account);
                            }
                        }
                        reader.Close();
                    }
                }
                catch
                {
                    return null;
                }
                _connection.Close();
                return alleUsers;
            }
        }
    }
}
