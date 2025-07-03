using Microsoft.Data.SqlClient;
using Entities;

namespace DataAccessLayer
{
    public class UserRepository
    {
        private readonly SqlConnection conn;

        public UserRepository() => conn = DBHelper.GetConnection();

        public UserModel? GetUserByEmail(string email)
        {
            string query = "SELECT * FROM Users WHERE Email = @Email";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Email", email);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new UserModel
                {
                    Id = (int)reader["Id"],
                    Email = reader["Email"].ToString()!
                };
            }
            conn.Close();
            return null;
        }

        public void AddUser(UserModel user)
        {
            string query = "INSERT INTO Users (Email) VALUES (@Email)";
            using SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Email", user.Email);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
