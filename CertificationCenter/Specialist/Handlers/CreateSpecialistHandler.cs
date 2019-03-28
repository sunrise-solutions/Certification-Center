using Mapster;
using MediatR;
using Specialist.Commands;
using Specialist.Data;
using Specialist.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Specialist.Handlers
{
    public class CreateSpecialistHandler : IRequestHandler<CreateSpecialistCommand, MedicalSpecialist>
    {
        private readonly SpecialistContext _context;
        private readonly TimeSpan _expirationTime;

        public CreateSpecialistHandler(SpecialistContext context)
        {
            _context = context;
        }

        public async Task<MedicalSpecialist> Handle(CreateSpecialistCommand request, CancellationToken cancellationToken)
        {
            var model = request.Adapt<MedicalSpecialist>();

            //_context.Specialists.Add(model);
            //await _context.SaveChangesAsync(cancellationToken);

            return model;
        }

    }
}
