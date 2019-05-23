using System;

namespace CertificationTest.Commands
{
    public class CreateCertificationTestCommand
    {
        public DateTime Date { get; set; }

        public int Result { get; set; }

        public int SpecialistId { get; set; }

        public int CourseId { get; set; }
    }
}
