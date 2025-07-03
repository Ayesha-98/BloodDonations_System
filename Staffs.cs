using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Entities;

namespace DataAccessLayer
{
    public class Staffs
    {
        private readonly SqlConnection conn;

        public Staffs() => conn = DBHelper.GetConnection();

        public List<StaffModel> GetAllStaff()
        {
            var staffList = new List<StaffModel>();
            using var cmd = new SqlCommand("SP_GetStaff", conn)
            { CommandType = CommandType.StoredProcedure };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                staffList.Add(new StaffModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Role = reader["Role"].ToString(),
                    Phone = reader["Phone"].ToString(),
                });
            }
            conn.Close();
            return staffList;
        }

        public void AddStaff(StaffModel obj)
        {
            using var cmd = new SqlCommand("SP_SaveStaff", conn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Role", obj.Role);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateStaff(StaffModel obj)
        {
            using var cmd = new SqlCommand("SP_UpdateStaff", conn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@Id", obj.Id);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Role", obj.Role);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteStaff(int id)
        {
            using var cmd = new SqlCommand("SP_DeleteStaff", conn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
