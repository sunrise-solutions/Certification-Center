using MySql.Data.MySqlClient;
using Specialist.Data;
using Specialist.Model;
using System;
using System.Collections.Generic;

namespace Specialist.Handlers
{
    public class GetAllSpecialistsHandler
    {
        private readonly SpecialistContext _context;

        public GetAllSpecialistsHandler(SpecialistContext context)
        {
            _context = context;
        }

        public List<MedicalSpecialist> Handle()
        {
            List<MedicalSpecialist> list = new List<MedicalSpecialist>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Specialists", conn);

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
            return list;
        }
    }
}
