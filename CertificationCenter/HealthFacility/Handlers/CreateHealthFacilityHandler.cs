using HealthFacility.Commands;
using HealthFacility.Data;
using HealthFacility.Model;
using Mapster;
using MySql.Data.MySqlClient;

namespace HealthFacility.Handlers
{
    public class CreateHealthFacilityHandler
    {
        private readonly HealthFacilityContext _context;

        public CreateHealthFacilityHandler(HealthFacilityContext context)
        {
            _context = context;
        }

        public bool Handle(CreateHealthFacitityCommand request)
        {
            var model = request.Adapt<MedicalHealthFacility>();
            string address = string.Format("улица {0}, дом {1}, город {2}, страна {3}", model.Address.Street, model.Address.House, model.Address.City, model.Address.Country);
            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();
                string query = string.Format("insert into Health_Facilities(name, address) values('{0}', '{1}')",
                    model.Name, address);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.CloseAsync();
                }
            }

            return true;
        }
    }
}
