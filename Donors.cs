using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Entities;
using System.Data;

namespace DataAccessLayer
{
    public class Donors
    {
        private readonly SqlConnection conn;

        public Donors() => conn = DBHelper.GetConnection();

        public List<DonorModel> GetAllDonors()
        {
            var donors = new List<DonorModel>();
            using var cmd = new SqlCommand("SP_GetDonors", conn)
            { CommandType = CommandType.StoredProcedure };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                donors.Add(new DonorModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    BloodGroup = reader["BloodGroup"].ToString(),
                    City = reader["City"].ToString()
                });
            }
            conn.Close();         
            return donors;
        }

      
        public void AddDonor(DonorModel obj)
        {
            using var cmd = new SqlCommand("SP_SaveDonor", conn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@BloodGroup", obj.BloodGroup);
            cmd.Parameters.AddWithValue("@City", obj.City);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateDonor(DonorModel obj)
        {
            using var cmd = new SqlCommand("SP_UpdateDonor", conn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@Id", obj.Id);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@BloodGroup", obj.BloodGroup);
            cmd.Parameters.AddWithValue("@City", obj.City);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

       
        public void DeleteDonor(int id)
        {
            using var cmd = new SqlCommand("SP_DeleteDonor", conn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }


}
