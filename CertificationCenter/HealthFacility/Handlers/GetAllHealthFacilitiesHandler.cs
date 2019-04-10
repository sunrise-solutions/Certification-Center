using HealthFacility.Data;
using HealthFacility.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthFacility.Handlers
{
    public class GetAllHealthFacilitiesHandler
    {
        private readonly HealthFacilityContext _context;

        public GetAllHealthFacilitiesHandler(HealthFacilityContext context)
        {
            _context = context;
        }

        public List<MedicalHealthFacility> Handle()
        {
            List<MedicalHealthFacility> list = new List<MedicalHealthFacility>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Health_Facilities", conn);

                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string addressString = reader["address"].ToString();
                            Address address = Converter.ConvertToAddress(addressString);
                            list.Add(new MedicalHealthFacility()
                            {
                                Id = Convert.ToInt32(reader["faculty_id"]),
                                Name = reader["name"].ToString(),
                                Address = address,
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
