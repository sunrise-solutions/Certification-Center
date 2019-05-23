using MySql.Data.MySqlClient;
using Specialist.Data;
using Specialist.Model;
using System;
using System.Collections.Generic;

namespace Specialist.Handlers
{
    public class GetSpecialistByIdHandler
    {
        private readonly SpecialistContext _context;

        public GetSpecialistByIdHandler(SpecialistContext context)
        {
            _context = context;
        }

        public MedicalSpecialist Handle(int specialistId)
        {
            List<MedicalSpecialist> list = new List<MedicalSpecialist>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = "select * from Specialists where specialist_id=" + specialistId.ToString();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new MedicalSpecialist()
                            {
                                Id = Convert.ToInt32(reader["specialist_id"]),
                                LastName = reader["last_name"].ToString(),
                                FirstName = reader["first_name"].ToString(),
                                MiddleName = reader["middle_name"].ToString(),
                                Email = reader["email"].ToString(),
                                HealthFacilitiesFacultyId = Convert.ToInt32(reader["Health_Facilities_faculty_id"]),
                            });
                        }
                    }
                }
                catch
                {
                    return null;
                }
                finally
                {
                    conn.CloseAsync();
                }
            }
            return list[0];
        }
    }
}
