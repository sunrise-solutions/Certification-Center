using MySql.Data.MySqlClient;
using HealthFacility.Data;
using HealthFacility.Model;
using HealthFacility.Commands;
using Mapster;

namespace HealthFacility.Handlers
{
    public class UpdateHealthFacilityHandler
    {
        private readonly HealthFacilityContext _context;

        public UpdateHealthFacilityHandler(HealthFacilityContext context)
        {
            _context = context;
        }

        public bool Handle(int healthFacilityId, CreateHealthFacitityCommand request)
        {
            var model = request.Adapt<Model.MedicalHealthFacility>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();

                string query = string.Format("update health_facilities set name = '{1}', address= '{2}' where faculty_id={0}",
                    healthFacilityId.ToString(),
                    model.Name,
                    model.Address);

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
