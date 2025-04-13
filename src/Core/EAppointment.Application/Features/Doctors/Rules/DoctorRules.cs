using EAppointment.Application.Abstractions.Repositories;
using EAppointment.Application.Commons.Exceptions;
using EAppointment.Domain.Entities;
using System.Net;

namespace EAppointment.Application.Features.Doctors.Rules
{
    internal sealed record DoctorRules(IQueryRepository<Doctor> _doctorQueryRepository)
    {
        public async Task DoctorNotFound(Guid id, CancellationToken cancellationToken)
        {
            Doctor? doctor = await _doctorQueryRepository.GetAsync(id);
            _ = doctor ?? throw new BaseException(DoctorErrorType.DoctorNotFound, HttpStatusCode.NotFound);
        }
    }
}
