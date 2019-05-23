using HealthFacility.Data;
using HealthFacility.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthFacility.Handlers
{
    public class GetHealthFacilityByIdHandler
    {
        private readonly HealthFacilityContext _context;

        public GetHealthFacilityByIdHandler(HealthFacilityContext context)
        {
            _context = context;
        }

        public MedicalHealthFacility Handle(int facitityId)
        {
            List<MedicalHealthFacility> list = new List<MedicalHealthFacility>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = "select * from Health_Facilities where faculty_id=" + facitityId.ToString();
                MySqlCommand cmd = new MySqlCommand(query, conn);

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
            return list[0];
        }
    }
}
