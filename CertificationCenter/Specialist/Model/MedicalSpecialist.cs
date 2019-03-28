using System;
using System.Collections.Generic;
using System.Text;

namespace Specialist.Model
{
    public class MedicalSpecialist
    {
        public int SpecialistId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public int HealthFacilitiesFacultyId { get; set; }
    }
}
