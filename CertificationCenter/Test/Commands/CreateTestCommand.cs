using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Model;

namespace Test.Commands
{
    public class CreateTestCommand : IRequest<TrainingTest>
    {
        public DateTime Date { get; set; }

        public int Result { get; set; }

        public int SpecialistId { get; set; }

        public int TopicId { get; set; }
    }
}
