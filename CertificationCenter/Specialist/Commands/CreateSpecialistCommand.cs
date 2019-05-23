namespace Specialist.Commands
{
    public class CreateSpecialistCommand
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public int HealthFacilitiesFacultyId { get; set; }
    }
}
