using EAppointment.Application.Abstractions.Repositories;
using EAppointment.Application.Commons.Results;
using EAppointment.Application.Features.Doctors.DTOs;
using EAppointment.Application.Features.Doctors.Rules;
using EAppointment.Domain.Entities;
using Mapster;
using Mediator;

namespace EAppointment.Application.Features.Doctors.Commands.Update
{
    public readonly record struct UpdateDoctorCommandRequest(Guid Id, string FirstName, string LastName, int Department) : IRequest<Result<DoctorDTO>>;
    internal sealed class UpdateDoctorCommandHandler(ICommandRepository<Doctor> _doctorCommandRepository, DoctorRules _doctorRules) : IRequestHandler<UpdateDoctorCommandRequest, Result<DoctorDTO>>
    {
        public async ValueTask<Result<DoctorDTO>> Handle(UpdateDoctorCommandRequest request, CancellationToken cancellationToken)
        {
            await _doctorRules.DoctorNotFound(request.Id, cancellationToken);
            Doctor? data = _doctorCommandRepository.Update(request.Adapt<Doctor>());
            await _doctorCommandRepository.SaveAsync();
            return Result<DoctorDTO>.Success(data.Adapt<DoctorDTO>(), "Doctor updated successfully");
        }
    }
}
