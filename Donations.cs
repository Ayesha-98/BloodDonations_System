using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Entities;

namespace DataAccessLayer
{
    public class Donations
    {
        private readonly SqlConnection conn;

        public Donations() => conn = DBHelper.GetConnection();

        public List<DonationModel> GetAllDonations()
        {
            var list = new List<DonationModel>();
            using var cmd = new SqlCommand("SP_GetDonations", conn)
            { CommandType = CommandType.StoredProcedure };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new DonationModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    DonorId = Convert.ToInt32(reader["DonorId"]),
                    DonationDate = Convert.ToDateTime(reader["DonationDate"]),
                    VolumeML = reader["VolumeML"] as int?,
                    StaffId = reader["StaffId"] as int?,
                    Remarks = reader["Remarks"]?.ToString()
                });
            }
            conn.Close();
            return list;
        }

        public void AddDonation(DonationModel obj)
        {
            using var cmd = new SqlCommand("SP_SaveDonation", conn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@DonorId", obj.DonorId);
            cmd.Parameters.AddWithValue("@DonationDate", obj.DonationDate);
            cmd.Parameters.AddWithValue("@VolumeML", (object?)obj.VolumeML);
            cmd.Parameters.AddWithValue("@StaffId", (object?)obj.StaffId);
            cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateDonation(DonationModel obj)
        {
            using var cmd = new SqlCommand("SP_UpdateDonation", conn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@Id", obj.Id);
            cmd.Parameters.AddWithValue("@DonorId", obj.DonorId);
            cmd.Parameters.AddWithValue("@DonationDate", obj.DonationDate);
            cmd.Parameters.AddWithValue("@VolumeML", (object?)obj.VolumeML ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StaffId", (object?)obj.StaffId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Remarks", obj.Remarks ?? string.Empty);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteDonation(int id)
        {
            using var cmd = new SqlCommand("SP_DeleteDonation", conn)
            { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

