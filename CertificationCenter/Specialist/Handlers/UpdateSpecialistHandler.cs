using MySql.Data.MySqlClient;
using Specialist.Data;
using Specialist.Model;
using Specialist.Commands;
using Mapster;

namespace Specialist.Handlers
{
    public class UpdateSpecialistHandler
    {
        private readonly SpecialistContext _context;

        public UpdateSpecialistHandler(SpecialistContext context)
        {
            _context = context;
        }

        public bool Handle(int specialistId, CreateSpecialistCommand request)
        {
            var model = request.Adapt<Model.MedicalSpecialist>();

            using (MySqlConnection conn = _context.GetConnection())
            {
                conn.Open();

                string query = string.Format("update specialists set last_name = '{1}', first_name= '{2}' middle_name = '{3}'" +
                    "email = '{4}', password_hash = '{5}', Health_Facilities_faculty_id = {6} where Health_Facilities_faculty_id ={0}",
                    specialistId.ToString(),
                    model.LastName,
                    model.FirstName,
                    model.MiddleName,
                    model.Email,
                    model.PasswordHash,
                    model.HealthFacilitiesFacultyId);
                
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
