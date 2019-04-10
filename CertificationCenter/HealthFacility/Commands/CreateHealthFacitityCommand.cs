using HealthFacility.Model;

namespace HealthFacility.Commands
{
    public class CreateHealthFacitityCommand
    {
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
