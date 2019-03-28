using MySql.Data.MySqlClient;
using Specialist.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specialist.Data
{
    public class SpecialistContext
    {
        public string ConnectionString { get; set; }

        public SpecialistContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<MedicalSpecialist> GetAllSpecialists()
        {
            List<MedicalSpecialist> list = new List<MedicalSpecialist>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Specialists", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MedicalSpecialist()
                        {
                            SpecialistId = Convert.ToInt32(reader["specialist_id"]),
                            LastName = reader["last_name"].ToString(),
                            FirstName = reader["first_name"].ToString(),
                            MiddleName = reader["middle_name"].ToString(),
                            Email = reader["email"].ToString(),
                            HealthFacilitiesFacultyId = Convert.ToInt32(reader["Health_Facilities_faculty_id"]),
                        });
                    }
                }
            }
            return list;
        }

        public List<MedicalSpecialist> GetSpecialistById(int specialistId)
        {
            List<MedicalSpecialist> list = new List<MedicalSpecialist>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from Specialists where specialist_id=" + specialistId.ToString();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MedicalSpecialist()
                        {
                            SpecialistId = Convert.ToInt32(reader["specialist_id"]),
                            LastName = reader["last_name"].ToString(),
                            FirstName = reader["first_name"].ToString(),
                            MiddleName = reader["middle_name"].ToString(),
                            Email = reader["email"].ToString(),
                            HealthFacilitiesFacultyId = Convert.ToInt32(reader["Health_Facilities_faculty_id"]),
                        });
                    }
                }
            }
            return list;
        }

        public bool CreateSpecialist(MedicalSpecialist specialist)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = string.Format("insert into Specialists(last_name, first_name, middle_name, email, password_hash, Health_Facilities_faculty_id) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", 
                        specialist.LastName, specialist.FirstName, specialist.MiddleName, 
                        specialist.Email, specialist.PasswordHash, specialist.HealthFacilitiesFacultyId);
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
