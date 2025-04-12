using EAppointment.Application.Abstractions.Repositories;
using EAppointment.Application.Commons.Results;
using EAppointment.Domain.Entities;
using Mediator;

namespace EAppointment.Application.Features.Doctors.Commands.Delete
{
    public sealed record DeleteDoctorCommandRequest(Guid id) : IRequest<Result<string>>;
    internal sealed class DeleteDoctorCommandHandler(ICommandRepository<Doctor> _doctorCommandRepository) : IRequestHandler<DeleteDoctorCommandRequest, Result<string>>
    {
        public async ValueTask<Result<string>> Handle(DeleteDoctorCommandRequest request, CancellationToken cancellationToken)
        {
            await _doctorCommandRepository.DeleteAsync(request.id);
            await _doctorCommandRepository.SaveAsync();

            return Result<string>.Success("Doctor deleted successfully.");
        }
    }
}
