using System;

namespace CertificationTest.Model
{
    public class CertificationTest
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Result { get; set; }

        public int SpecialistId { get; set; }

        public int CourseId { get; set; }
    }
}
